using Microsoft.AspNetCore.SignalR;

namespace Pixey.Website.SignalHubs
{
    public class RequestIdentityUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        { 
            return connection.User?.Identity?.Name;
        }
    }
}