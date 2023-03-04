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
            //TODO implement this
            // command.Execute();
            throw new NotImplementedException();
            await Clients.All.SendAsync("ReceiveSound", command);
        }
    }
}
