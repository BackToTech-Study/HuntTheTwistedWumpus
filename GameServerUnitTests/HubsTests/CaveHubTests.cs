using GameServer.Caverns;
using GameServer.Commands;
using GameServer.Hubs;
using GameServer.Messages;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace GameServerUnitTests.HubsTests
{
    [TestClass]
    public class CaveHubTests
    {
        [TestMethod]
        public async Task SendCavernSound_ShouldSendMessageToAllClients()
        {
            // Arrange
            var mockClients = new Mock<IHubCallerClients>();
            var mockClientProxy = new Mock<IClientProxy>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var caveHub = new CaveHub();
            caveHub.Clients = mockClients.Object;

            bool wasCalled = false;
            string message = "";
            var sound = new Mock<Sound>(1, "TestSound");

            mockClientProxy.Setup(x => x.SendCoreAsync("ReceiveSound", It.IsAny<object[]>(), default))
                .Callback(() =>
                {
                    wasCalled = true;
                    message = sound.Object.Name;
                })
                .Returns(Task.CompletedTask);

            var makeSoundCommand = new Mock<MakeSoundCommand>(sound.Object);
            var room = new Mock<Room>("1");

            // Act
            await caveHub.SendCavernSound(makeSoundCommand.Object, room.Object);

            // Assert
            Assert.IsTrue(wasCalled, "The method `SendCoreAsync` was not called.");
            Assert.AreEqual("TestSound", message);
        }
    }
}