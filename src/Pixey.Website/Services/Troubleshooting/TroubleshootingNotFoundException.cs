using System;

namespace Pixey.Website.Services.Troubleshooting
{
    public class TroubleshootingNotFoundException : Exception
    {
        public TroubleshootingNotFoundException(string id)
            : base($"Troubleshooting with id {id} could not be found.")
        {
        }
    }
}