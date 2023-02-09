using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleClient.Connection
{
    public class SignalRClient : IConnectionChannelClient
    {
        public HubConnection _playerHubConnection;
        public HubConnection _caveHubConnection;
        public SignalRClient()
        {
            _playerHubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7252/playerhub")
                .WithAutomaticReconnect()
                .Build();

            _caveHubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7252/cavehub")
                .WithAutomaticReconnect()
                .Build();
        }
        public async Task Connect() 
        {
            try
            {
                await _playerHubConnection.StartAsync();
                await _caveHubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
