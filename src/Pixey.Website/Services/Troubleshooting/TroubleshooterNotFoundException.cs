using System;

namespace Pixey.Website.Services.Troubleshooting
{
    public class TroubleshooterNotFoundException : Exception
    {
        public TroubleshooterNotFoundException(string id)
            : base($"Troubleshooter with id {id} could not be found.")
        {
        }
    }
}