using GameServer.Caverns;
using GameServer.Players;
using Moq;

namespace GameServerUnitTests.PlayerTests
{
    [TestClass]
    public class PlayerTests
    {
        public IRoom? _room;
        public Player? _player;

        [TestInitialize]
        public void PlayerSetup()
        {
            _room = new Room("Room1");
            _player = new Player(_room);
        }

        [TestMethod]
        public void WalkToRoom_ShouldMovePlayerToOtherRoom()
        {
            if (_player == null)
            {
                Assert.Fail("Player is null");
                return;
            }

            // Arrange
            Mock<IRoom> roomMock = new Mock<IRoom>();

            // Act
            _player.WalkToRoom(roomMock.Object);

            // Assert
            Assert.IsFalse(_player.GetCurrentRoom() == _room);
            Assert.IsTrue(_player.GetCurrentRoom() == roomMock.Object);
        }
    }
}
