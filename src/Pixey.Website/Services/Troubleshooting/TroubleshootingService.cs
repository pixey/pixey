using System;
using Microsoft.AspNetCore.SignalR;
using Pixey.Domain.Diagnostics.Troubleshooting;
using Pixey.Website.Caching;
using Pixey.Website.SignalHubs;

namespace Pixey.Website.Services.Troubleshooting
{
    public class TroubleshootingService : ITroubleshootingService
    {
        private static readonly TimeSpan TroubleshooterSlidingExpiration = TimeSpan.FromMinutes(30);

        private readonly ITroubleshooterFactory _troubleshooterFactory;
        private readonly IHubContext<UpdateHub, IUpdateHubClient> _updateHubContext;
        private readonly ISlidingExpirationMemoryStore<TroubleshooterStoreEntry> _entryStore;

        public TroubleshootingService(
            ITroubleshooterFactory troubleshooterFactory,
            IHubContext<UpdateHub, IUpdateHubClient> updateHubContext,
            ISlidingExpirationMemoryStoreFactory troubleshooterStoreFactory)
        {
            _entryStore = troubleshooterStoreFactory.Create<TroubleshooterStoreEntry>(TroubleshooterSlidingExpiration);
            _troubleshooterFactory = troubleshooterFactory;
            _updateHubContext = updateHubContext;

            _entryStore.RemovingExpiredItem += UnsubscribeEntryEvents;
        }

        public string StartTroubleshooting(string userId)
        {
            var id = Guid.NewGuid().ToString("N");
            var troubleshooter = _troubleshooterFactory.Create();
            var entry = new TroubleshooterStoreEntry(troubleshooter, userId);

            entry.StatusChanged += HandleStatusChanged;

            _entryStore.Add(id, entry);

            troubleshooter.Start();

            return id;
        }

        public TroubleshootingStatus GetTroubleshootingStatus(string id)
        {
            if (!_entryStore.TryGet(id, out var entry))
            {
                throw new TroubleshooterNotFoundException(id);
            }

            return entry.Troubleshooter.GetStatus();
        }

        public void CancelTroubleshooting(string id)
        {
            if(!_entryStore.TryGet(id, out var entry))
            {
                throw new TroubleshooterNotFoundException(id);
            }

            entry.Troubleshooter.Cancel();
        }

        private void UnsubscribeEntryEvents(object sender, ItemEventArgs<TroubleshooterStoreEntry> e)
        {
            e.Item.StatusChanged -= HandleStatusChanged;
            e.Item.Dispose();
        }

        private void HandleStatusChanged(object sender, TroubleshooterStoreEntryEventArgs e)
        {
            _updateHubContext.Clients.User(e.UserId).UpdateTroubleshootingStatus(e.Status).Wait();
        }
    }
}