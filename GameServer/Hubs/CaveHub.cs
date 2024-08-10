using GameServer.Caverns;
using GameServer.Commands;
using GameServer.Players;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

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

        public override async Task OnConnectedAsync()
        {
            string welcomeMessage = "Welcome to the game!";
            await Clients.Caller.SendAsync("ReceiveWelcomeMessage", welcomeMessage);

            await SendAvailableCommands();

            await base.OnConnectedAsync();
        }

        public async Task ProcessPlayerCommand(string command)
        {
            Console.WriteLine($"Received command: {command}");

            GameManager gameManager = GameManager.GetInstance;
            Player player = gameManager.GetPlayer();
            IRoom? room;

            if (command.StartsWith("Walk to ", StringComparison.Ordinal))
            {
                string destination = command.Substring(8);
                room = gameManager.GetRoom(destination);

                if (room == null)
                {
                    await Clients.Caller.SendAsync("CommandProcessed", "Invalid command.");
                    return;
                }

                var commandFactory = new CommandFactory();
                ICommand commandToExecute = commandFactory.CreateCommand<WalkToCommand, IRoom?>(room);

                if (commandToExecute != null)
                {
                    commandToExecute.Execute(player);

                    await SendAvailableCommands();
                }
            }
            else
            {
                await Clients.Caller.SendAsync("CommandProcessed", "Invalid command.");
            }
        }

        // Helpers
        private IReadOnlyList<IRoom> UpdateValidWalkToRooms()
        {
            GameManager gameManager = GameManager.GetInstance;
            Player player = gameManager.GetPlayer();
            IRoom currentRoom = player.GetCurrentRoom();

            return currentRoom.GetConnectedRooms();
        }

        private async Task SendAvailableCommands()
        {
            List<string> commands = new List<string>();
            IReadOnlyList<IRoom> rooms = UpdateValidWalkToRooms();

            foreach (var room in rooms)
            {
                string walkTo = "Walk to ";
                commands.Add(walkTo + room.Name);
            }

            await Clients.Caller.SendAsync("ReceiveAvailableCommands", commands);
        }
    }
}
