using System;

namespace Pixey.Domain.Diagnostics.Troubleshooting
{
    public interface ITroubleshooter
    {
        event EventHandler<TroubleshootingStatusEventArgs> StatusChanged;

        TroubleshootingStatus GetStatus();

        void Start();

        void Cancel();
    }
}