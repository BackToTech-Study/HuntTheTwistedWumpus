using GameServer.Commands;
using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace GameServerUnitTests.HubsTests
{
    [TestClass]
    public class CaveHubTests
    {
        [TestMethod]
        public async Task SendMessage_ShouldSendMessageToAllClients()
        {
            // Arrange
            var mockClients = new Mock<IHubCallerClients>();
            var mockClientProxy = new Mock<IClientProxy>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var caveHub = new CaveHub();
            caveHub.Clients = mockClients.Object;

            bool wasCalled = false;
            mockClientProxy.Setup(x => x.SendCoreAsync("ReceiveSound", It.IsAny<object[]>(), default))
                .Callback(() =>
                {
                    wasCalled = true;
                })
                .Returns(Task.CompletedTask);

            var makeSoundCommand = new Mock<ICommand>();

            //TODO refacor
            throw new NotImplementedException();
            // makeSoundCommand.Setup(x => x.Execute());

            // Act
            await caveHub.SendMessage(makeSoundCommand.Object);

            // Assert
            Assert.IsTrue(wasCalled, "The method `SendCoreAsync` was not called.");
        }
    }
}