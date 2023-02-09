using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleClient.Connection
{
    public class SignalRClient : IConnectionChannelClient
    {
        public HubConnection _playerHubConnection;
        public HubConnection _caveHubConnection;
        private const string _baseUrl = "https://localhost:7252";
        
        public SignalRClient()
        {
            _playerHubConnection = new HubConnectionBuilder()
                .WithUrl(_baseUrl + "/playerhub")
                .WithAutomaticReconnect()
                .Build();

            _caveHubConnection = new HubConnectionBuilder()
                .WithUrl(_baseUrl + "/cavehub")
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
