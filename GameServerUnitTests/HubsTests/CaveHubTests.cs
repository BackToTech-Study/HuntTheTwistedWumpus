using GameServer.Caverns;
using GameServer.Commands;
using GameServer.Hubs;
using GameServer.Messages;
using Microsoft.AspNetCore.SignalR;
using Moq;
using NuGet.Frameworks;

namespace GameServerUnitTests.HubsTests
{
    [TestClass]
    public class CaveHubTests
    {
        public Mock<IHubCallerClients>? _clientsMock;
        public Mock<IClientProxy>? _clientProxyMock;
        public CaveHub? _caveHub;

        [TestInitialize]
        public void SetupHub()
        {
            _clientsMock = new Mock<IHubCallerClients>();
            _clientProxyMock = new Mock<IClientProxy>();       
            _clientsMock.Setup(clients => clients.All).Returns(_clientProxyMock.Object);
            _caveHub = new CaveHub()
            {
                Clients = _clientsMock.Object
            };
        }

        [TestMethod]
        public async Task SendCavernSound_ShouldSendMessageToAllClients()
        {
            if (_clientsMock == null || _clientProxyMock == null || _caveHub == null)
            {
                Assert.Fail("Mock setup failed");
                return;
            }

            bool wasCalled = false;
            string message = "";
            var sound = new Mock<Sound>(1, "TestSound"); 

            _clientProxyMock.Setup(x => x.SendCoreAsync("ReceiveSound", It.IsAny<object[]>(), default))
                .Callback(() =>
                {
                    wasCalled = true;
                    message = sound.Object.Name;
                })
                .Returns(Task.CompletedTask);

            var makeSoundCommand = new Mock<MakeSoundCommand>(sound.Object);
            var room = new Mock<Room>("1");

            // Act
            await _caveHub.SendCavernSound(makeSoundCommand.Object, room.Object);

            // Assert
            Assert.IsTrue(wasCalled, "The method `SendCoreAsync` was not called.");
            Assert.AreEqual("TestSound", message);
        }

        [TestMethod]
        public async Task OnConnectedAsync_ShouldSendWelcomeMessageAndCommands()
        {
            if (_clientsMock == null || _clientProxyMock == null || _caveHub == null)
            {
                Assert.Fail("Mock setup failed");
                return;
            }

            // Arrange
            var welcomeMessage = "Welcome to the game!";
            var expectedCommands = new List<string> { "Exit", "WalkToCommand" };

            var receivedMessages = new List<(string MethodName, object[] Args)>();

            _clientsMock.Setup(clients => clients.Caller).Returns(_clientProxyMock.Object);
            _clientProxyMock
                .Setup(c => c.SendCoreAsync(It.IsAny<string>(), It.IsAny<object[]>(), It.IsAny<CancellationToken>()))
                .Callback<string, object[], CancellationToken>((method, args, token) =>
                {
                    receivedMessages.Add((method, args));
                })
                .Returns(Task.CompletedTask);

            // Act
            await _caveHub.OnConnectedAsync();

            // Assert
            Assert.AreEqual(2, receivedMessages.Count, "Expected two messages to be sent.");

            var welcomeCall = receivedMessages.Find(m => m.MethodName == "ReceiveWelcomeMessage");
            Assert.IsNotNull(welcomeCall, "Expected 'ReceiveWelcomeMessage' method call.");
            Assert.AreEqual(welcomeMessage, welcomeCall.Args[0]);

            var commandsCall = receivedMessages.Find(m => m.MethodName == "ReceiveAvailableCommands");
            Assert.IsNotNull(commandsCall, "Expected 'ReceiveAvailableCommands' method call.");
            CollectionAssert.AreEqual(expectedCommands, (List<string>)commandsCall.Args[0]);
        }
    }
}