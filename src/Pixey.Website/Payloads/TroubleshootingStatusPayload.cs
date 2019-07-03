using Pixey.Domain.Diagnostics.Troubleshooting;

namespace Pixey.Website.Payloads
{
    public class TroubleshootingStatusPayload
    {
        public static TroubleshootingStatusPayload FromDomain(TroubleshootingStatus status)
        {
            return new TroubleshootingStatusPayload();
        }
    }
}