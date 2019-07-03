namespace Pixey.Domain.Diagnostics.Troubleshooting
{
    public class TroubleshootingStatus
    {
        public int Counter { get; }

        public TroubleshootingStatus(int counter)
        {
            Counter = counter;
        }
    }
}