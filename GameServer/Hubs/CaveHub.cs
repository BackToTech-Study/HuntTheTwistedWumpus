using Microsoft.AspNetCore.SignalR;

namespace GameServer.Hubs
{
    public class CaveHub : Hub
    {
        public Task MakeSound(string sound)
        {
            return Clients.All.SendAsync("ReceiveSound", sound);
        }
    }
}
