using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace GameServerUnitTests.HubsTests
{
    [TestClass]
    public class PlayerHubTests
    {
        [TestMethod]
        public void SendMessage_ShouldSendMessageToAllClients()
        {
            // Arrange
            var mockClients = new Mock<IHubCallerClients>();
            var mockClientProxy = new Mock<IClientProxy>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var playerHub = new PlayerHub();
            playerHub.Clients = mockClients.Object;

            bool wasCalled = false;
            mockClientProxy.Setup(x => x.SendCoreAsync("ReceiveMessage", It.IsAny<object[]>(), default))
                    .Callback(() =>
                    {
                        wasCalled = true;
                    });

            // Act
            playerHub.SendMessage("Test user", "Player message");

            // Assert
            Assert.IsTrue(wasCalled, "The method `SendCoreAsync` was not called.");
        }
    }
}
