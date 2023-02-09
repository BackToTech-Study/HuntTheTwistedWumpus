using ConsoleClient.Connection;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks.Dataflow;

namespace ConsoleClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            SignalRClient signalRClient = new SignalRClient();
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