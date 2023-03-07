using ConsoleClient.Connection;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            builder.ConfigureServices(Services =>
            {
                Services.AddSingleton(configuration);
                Services.AddScoped<ConfigVars, ConfigVars>();
                Services.AddScoped<SignalRClient, SignalRClient>();
            });

            var app = builder.Build();

            var serviceProvider = app.Services;

            SignalRClientFactory.SetScope(serviceProvider);
            var signalRClient = SignalRClientFactory.GetSignalRClient();
            
            Console.WriteLine("Player hub status: " + signalRClient._playerHubConnection.State);
            Console.WriteLine("Cave hub status: " + signalRClient._caveHubConnection.State);

            await signalRClient.Connect();
            Console.WriteLine("Player hub status: " + signalRClient._playerHubConnection.State);
            Console.WriteLine("Cave hub status: " + signalRClient._caveHubConnection.State);

            signalRClient._caveHubConnection.On<string>("ReceiveSound", (sound) =>
            {
                Console.WriteLine();
            });

            Console.ReadLine();
        }
    }
}