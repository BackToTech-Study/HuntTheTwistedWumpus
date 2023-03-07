using GameServer.Caverns;
using GameServer.Commands;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace GameServer.Hubs
{
    [SignalRHub]
    public class CaveHub : Hub
    {
        public async Task SendCavernSound(ICommand command, Room room)
        {
            command.Execute(room);

            await Clients.All.SendAsync("ReceiveSound", command);
        }
    }
}
