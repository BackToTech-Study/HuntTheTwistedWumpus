using ConsoleClient.Commands;
using Microsoft.AspNetCore.SignalR.Client;
using static ConsoleClient.ConfigVars;

namespace ConsoleClient.Connection
{
    public class SignalRClient : IConnectionChannelClient
    {
        public HubConnection _playerHubConnection;
        public HubConnection _caveHubConnection;
        private List<string> _commandsBuffer;
        
        public SignalRClient(ConfigVars configuration)
        {          
            _playerHubConnection = new HubConnectionBuilder()
                .WithUrl(configuration.BaseUrl + "/playerhub")
                .WithAutomaticReconnect()
                .Build();

            _caveHubConnection = new HubConnectionBuilder()
                .WithUrl(configuration.BaseUrl + "/cavehub")
                .WithAutomaticReconnect()
                .Build();

            _commandsBuffer = new List<string>();
        }

        public async Task Connect()
        {
            try
            {
                await _playerHubConnection.StartAsync();
                await _caveHubConnection.StartAsync();
                ReceiveMessages();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SendPlayerCommand(string message)
        {
            await _caveHubConnection.SendAsync("ProcessPlayerCommand", message);
        }

        private void ReceiveMessages()
        {
            _caveHubConnection.On<string>("ReceiveWelcomeMessage", (message) =>
            {
                Console.WriteLine(message);
            });

            _caveHubConnection.On<List<string>>("ReceiveAvailableCommands", (commands) =>
            {
                _commandsBuffer.Clear();
                Console.WriteLine("Available commands:");
                for (int index = 0; index < commands.Count; ++index)
                {
                    _commandsBuffer.Add(commands[index]);
                    Console.WriteLine($"{index}: {commands[index]}");
                }
            });
        }

        public IReadOnlyList<string> GetCommands() { return _commandsBuffer; }
    }
}
