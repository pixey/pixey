namespace Pixey.Domain.Diagnostics.Troubleshooting
{
    public class TroubleshooterFactory : ITroubleshooterFactory
    {
        public ITroubleshooter Create()
        {
            return new Troubleshooter();
        }
    }
}