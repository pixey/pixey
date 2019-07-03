using System;
using Pixey.Domain.Diagnostics.Troubleshooting;

namespace Pixey.Website.Services.Troubleshooting
{
    internal class TroubleshooterStoreEntry : IDisposable
    {
        public TroubleshooterStoreEntry(ITroubleshooter troubleshooter, string userId)
        {
            Troubleshooter = troubleshooter;
            UserId = userId;

            troubleshooter.StatusChanged += HandleStatusChanged;
        }

        public event EventHandler<TroubleshooterStoreEntryEventArgs> StatusChanged;

        public ITroubleshooter Troubleshooter { get; }

        public string UserId { get; }

        public void Dispose()
        {
            Troubleshooter.StatusChanged -= HandleStatusChanged;
        }

        private void HandleStatusChanged(object sender, TroubleshootingStatusEventArgs e)
        {
            var args = new TroubleshooterStoreEntryEventArgs(UserId, e.Status);

            StatusChanged?.Invoke(this, args);
        }
    }
}