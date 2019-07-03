using Microsoft.AspNetCore.SignalR;

namespace Pixey.Website.SignalHubs
{
    public class UpdateHub : Hub<IUpdateHubClient>
    {
    }
}