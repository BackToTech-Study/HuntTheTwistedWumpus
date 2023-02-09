using ConsoleClient.Connection;
using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleClientUnitTests.ConnectionTests
{
    [TestClass]
    public class SignalRClientTests
    {
        [TestMethod]
        public async Task Connect_ShouldStartHubConnections()
        {
            // Arrange
            var signalRClient = new SignalRClient();

            // Act
            await signalRClient.Connect();

            //Assert
            Assert.IsTrue(signalRClient._playerHubConnection.State == HubConnectionState.Connected);
            Assert.IsTrue(signalRClient._caveHubConnection.State == HubConnectionState.Connected);
        }
    }
}
