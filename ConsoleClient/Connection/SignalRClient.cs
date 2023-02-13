using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace ConsoleClient.Connection
{
    public class SignalRClient : IConnectionChannelClient
    {
        public HubConnection _playerHubConnection;
        public HubConnection _caveHubConnection;
        private readonly string _baseUrl;
        
        public SignalRClient()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _baseUrl = configuration.GetSection("SignalR")["BaseUrl"];

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
