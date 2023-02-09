using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace GameServer.Hubs
{
    [SignalRHub]
    public class CaveHub : Hub
    {
        public Task MakeSound(string sound)
        {
            return Clients.All.SendAsync("ReceiveSound", sound);
        }
    }
}
