using GameServer.Caverns;
using GameServer.Players;
using Moq;

namespace GameServerUnitTests.RoomTests
{
    [TestClass]
    public class RoomTests
    {
        public IRoom? _room;

        [TestInitialize]
        public void RoomSetup()
        {
            _room = new Room("Room 1");
        }

        [TestMethod]
        public void AddAdjacentRoom_ShouldLinkRoomToCurrentRoom()
        {
            // Arrange
            if (_room == null)
            {
                Assert.Fail("Room is null");
                return;
            }

            IRoom room2 = new Room("Room 2");

            // Act
            _room.AddAdjacentRoom(room2);

            // Assert
            Assert.IsTrue(_room.GetConnectedRooms().Contains(room2));
        }

        [TestMethod]
        public void GetConnectedRooms_ShouldReturnListOfConnectedRooms()
        {
            // Arrange
            if (_room == null)
            {
                Assert.Fail("Room is null");
                return;
            }

            IRoom room2 = new Room("Room 2");
            IRoom room3 = new Room("Room 3");
            _room.AddAdjacentRoom(room2);
            _room.AddAdjacentRoom(room3);

            // Act
            var connectedRooms = _room.GetConnectedRooms();

            // Assert
            Assert.IsTrue(connectedRooms.Contains(room2));
            Assert.IsTrue(connectedRooms.Contains(room3));
            Assert.AreEqual(2, connectedRooms.Count);
        }

        [TestMethod]
        public void ReceivePlayer_ShouldAddPlayerToList()
        {
            // Arrange
            if (_room == null)
            {
                Assert.Fail("Room is null");
                return;
            }

            Mock<IRoom> roomMock = new Mock<IRoom>();
            Mock<Player> player = new Mock<Player>();
            //Act
            _room.ReceivePlayer(player.Object);

            //Assert
            Assert.IsTrue(_room.GetPlayers().Contains(player.Object));
        }

        [TestMethod]
        public void RemovePlayer_ShouldRemovePlayerFromList()
        {
            // Arrange
            if (_room == null)
            {
                Assert.Fail("Room is null");
                return;
            }

            Mock<Player> player = new Mock<Player>();
            _room.ReceivePlayer(player.Object);
            
            //Act
            _room.RemovePlayer(player.Object);

            //Assert
            Assert.IsFalse(_room.GetPlayers().Contains(player.Object));
        }
    }
}

