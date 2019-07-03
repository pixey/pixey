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
        private readonly ISlidingExpirationMemoryStore<ITroubleshooter> _troubleshooterStore;

        public TroubleshootingService(
            ITroubleshooterFactory troubleshooterFactory,
            IHubContext<UpdateHub, IUpdateHubClient> updateHubContext,
            ISlidingExpirationMemoryStoreFactory troubleshooterStoreFactory)
        {
            _troubleshooterFactory = troubleshooterFactory;
            _updateHubContext = updateHubContext;
            _troubleshooterStore = troubleshooterStoreFactory.Create<ITroubleshooter>(TroubleshooterSlidingExpiration);

            _troubleshooterStore.RemovingExpiredItem += UnsubscribeTroubleshooterEvents;
        }

        public string StartTroubleshooting(string userId)
        {
            var id = Guid.NewGuid().ToString("N");
            var troubleshooter = _troubleshooterFactory.Create();

            troubleshooter.StatusChanged += HandleStatusChanged;

            _troubleshooterStore.Add(id, troubleshooter);

            troubleshooter.Start();

            return id;
        }

        public TroubleshootingStatus GetTroubleshootingStatus(string id)
        {
            if (!_troubleshooterStore.TryGet(id, out var troubleshooter))
            {
                throw new TroubleshootingNotFoundException(id);
            }

            return troubleshooter.GetStatus();
        }

        public void CancelTroubleshooting(string id)
        {
            if(!_troubleshooterStore.TryGet(id, out var troubleshooter))
            {
                throw new TroubleshootingNotFoundException(id);
            }

            troubleshooter.Cancel();
        }

        private void UnsubscribeTroubleshooterEvents(object sender, ItemEventArgs<ITroubleshooter> e)
        {
            e.Item.StatusChanged -= HandleStatusChanged;
        }

        private void HandleStatusChanged(object sender, TroubleshootingStatusEventArgs e)
        {
            _updateHubContext.Clients.All.UpdateTroubleshootingStatus(e.Status).Wait();
        }
    }
}