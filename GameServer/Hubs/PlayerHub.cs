using Microsoft.AspNetCore.SignalR;
using System.Reflection.Metadata.Ecma335;

namespace GameServer.Hubs
{
    public class PlayerHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
