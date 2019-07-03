using Pixey.Domain.Diagnostics.Troubleshooting;

namespace Pixey.Website.Services.Troubleshooting
{
    public interface ITroubleshootingService
    {
        string StartTroubleshooting(string userId);

        TroubleshootingStatus GetTroubleshootingStatus(string id);

        void CancelTroubleshooting(string id);
    }
}