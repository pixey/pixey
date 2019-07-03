using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Pixey.Domain.Diagnostics.Troubleshooting;

namespace Pixey.Website.SignalHubs
{
    public interface IUpdateHubClient
    {
        [HubMethodName("message")]
        Task UpdateTroubleshootingStatus(TroubleshootingStatus status);
    }
}