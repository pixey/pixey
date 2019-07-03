using System;
using Pixey.Domain.Diagnostics.Troubleshooting;

namespace Pixey.Website.Services.Troubleshooting
{
    internal class TroubleshooterStoreEntryEventArgs : EventArgs
    {
        public string UserId { get; }

        public TroubleshootingStatus Status { get; }

        public TroubleshooterStoreEntryEventArgs(string userId, TroubleshootingStatus status)
        {
            UserId = userId;
            Status = status;
        }
    }
}