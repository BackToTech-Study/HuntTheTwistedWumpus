using ConsoleClient;
using ConsoleClient.Connection;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ConsoleClientUnitTests.ConnectionTests
{
    [TestClass]
    public class SignalRClientTests
    {
        private SignalRClient? _signalRClient;

        [TestInitialize]
        public void Setup()
        {
            var configuration = new ConfigVars(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
            _signalRClient = new SignalRClient(configuration);
        }

        [TestMethod]
        public async Task Connect_ShouldStartHubConnections()
        {
            // Arrange
            if (_signalRClient == null)
            {
                Assert.Fail("SignalRClient was not initialized");
            }

            // Act
            await _signalRClient.Connect();

            //Assert
            Assert.IsTrue(_signalRClient._playerHubConnection.State == HubConnectionState.Connected);
            Assert.IsTrue(_signalRClient._caveHubConnection.State == HubConnectionState.Connected);
        }

        [TestMethod]
        public void ReceiveMessages_ShouldUpdateCommandsBuffer()
        {
            Assert.Fail("ReceiveMessages is private");
        }
    }
}
