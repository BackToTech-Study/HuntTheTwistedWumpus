using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace GameServer.Hubs
{
    [SignalRHub]
    public class PlayerHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
