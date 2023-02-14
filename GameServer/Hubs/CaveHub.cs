using GameServer.Commands;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace GameServer.Hubs
{
    [SignalRHub]
    public class CaveHub : Hub
    {
        public async Task SendMessage(ICommand command)
        {
            command.Execute();
            await Clients.All.SendAsync("ReceiveSound", command);
        }
    }
}
