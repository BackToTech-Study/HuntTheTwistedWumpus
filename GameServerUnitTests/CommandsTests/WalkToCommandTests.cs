using GameServer.Caverns;
using GameServer.Commands;
using GameServer.Players;
using Moq;

namespace GameServerUnitTests.CommandsTests
{
    [TestClass]
    public class WalkToCommandTests
    {
        [TestMethod]
        public void Execute_WalkToOtherRoomCommand()
        {
            // Arrange
            Mock<IRoom> roomMock1 = new Mock<IRoom>();
            Mock<IRoom> roomMock2 = new Mock<IRoom>();

            Player player = new Player(roomMock1.Object);
            var walkToCommand = new WalkToCommand(roomMock2.Object);

            // Act
            walkToCommand.Execute(player);

            // Assert
            Assert.IsFalse(player.GetCurrentRoom() == roomMock1.Object);
            Assert.IsTrue(player.GetCurrentRoom() == roomMock2.Object);
        }
    }
}
