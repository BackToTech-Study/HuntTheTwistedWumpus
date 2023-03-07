using ConsoleClient;
using ConsoleClient.Connection;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace ConsoleClientUnitTests.ConnectionTests
{
    [TestClass]
    public class SignalRClientTests
    {
        [TestMethod]
        public async Task Connect_ShouldStartHubConnections()
        {
            // Arrange
            var configuration = new ConfigVars(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());

            var signalRClient = new SignalRClient(configuration);

            // Act
            await signalRClient.Connect();

            //Assert
            Assert.IsTrue(signalRClient._playerHubConnection.State == HubConnectionState.Connected);
            Assert.IsTrue(signalRClient._caveHubConnection.State == HubConnectionState.Connected);
        }
    }
}
