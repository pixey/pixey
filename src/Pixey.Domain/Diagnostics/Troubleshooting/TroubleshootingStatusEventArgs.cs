using System;

namespace Pixey.Domain.Diagnostics.Troubleshooting
{
    public class TroubleshootingStatusEventArgs : EventArgs
    {
        public TroubleshootingStatusEventArgs(TroubleshootingStatus status)
        {
            Status = status;
        }

        public TroubleshootingStatus Status { get; }
    }
}