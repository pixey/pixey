using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pixey.Domain.Diagnostics.Troubleshooting
{
    public class Troubleshooter : ITroubleshooter
    {
        private int _counter;
        private Task _backgroundTask;

        private readonly CancellationTokenSource _cancellationTokenSource;

        public Troubleshooter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public event EventHandler<TroubleshootingStatusEventArgs> StatusChanged;

        public TroubleshootingStatus GetStatus()
        {
            return new TroubleshootingStatus(_counter);
        }

        public void Start()
        {

            // TODO: Validate it hasn't been started already
            _backgroundTask = RunTroubleshooting(_cancellationTokenSource.Token);
        }

        public void Cancel()
        {
            // TODO: Validate it hasn't been cancelled already

            _cancellationTokenSource.Cancel();
        }

        private async Task RunTroubleshooting(CancellationToken ct)
        {
            for (int i = 0; i < 10 && !ct.IsCancellationRequested; i++)
            {
                await Task.Delay(1000, ct);
                _counter++;

                OnStatusChanged();
            }
        }

        private void OnStatusChanged()
        {
            if (StatusChanged != null)
            {
                var status = GetStatus();
                var args = new TroubleshootingStatusEventArgs(status);

                StatusChanged?.Invoke(this, args);
            }
        }
    }
}