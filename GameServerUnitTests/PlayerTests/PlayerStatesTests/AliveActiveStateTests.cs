using GameServer.Caverns;
using GameServer.Players;
using GameServer.Players.PlayerStates;
using Moq;

namespace GameServerUnitTests.PlayerTests.PlayerStatesTests
{
    [TestClass]
    public class AliveActiveStateTests
    {
        public IRoom? _room;
        public Player? _player;

        [TestInitialize]
        public void RoomSetup()
        {
            _room = new Room("Room1");
            _player = new Player(_room);
        }

        [TestMethod]
        public void WalkToRoom_ShouldMovePlayerToOtherRoom()
        {
            if (_player == null || _room == null)
            {
                Assert.Fail("Player or Room is null");
                return;
            }

            // Arrange            
            Mock<IRoom> roomMock = new Mock<IRoom>();
            IState state = _player.GetState();

            // Act
            state.WalkToRoom(_player, roomMock.Object);

            // Assert
            Assert.IsFalse(_player.GetCurrentRoom() == _room);
            Assert.IsTrue(_player.GetCurrentRoom() == roomMock.Object);
        }
    }
}
