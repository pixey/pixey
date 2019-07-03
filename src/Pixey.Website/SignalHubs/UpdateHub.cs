using Microsoft.AspNetCore.SignalR;

namespace Pixey.Website.SignalHubs
{
    public class UpdateHub : Hub<IUpdateHubClient>
    {
        //internal async Task UpdateTroubleshootingStatus(string userId, TroubleshootingStatus troubleshootingStatus)
        //{
        //    // TODO: Translate to model

        //    await this.Clients.Group(userId)
        //        .UpdateTroubleshootingStatus(troubleshootingStatus)
        //        .ConfigureAwait(false);
        //}
    }
}