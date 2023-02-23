using GameServer.Room;

namespace GameServerUnitTests.RoomTests
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void AddAdjacentRoom_ShouldLinkRoomToCurrentRoom()
        {
            // Arrange
            IRoom room1 = new Room("Room 1");
            IRoom room2 = new Room("Room 2");

            // Act
            room1.AddAdjacentRoom(room2);

            // Assert
            Assert.IsTrue(room1.GetConnectedRooms().Contains(room2));
        }

        [TestMethod]
        public void GetConnectedRooms_ShouldReturnListOfConnectedRooms()
        {
            // Arrange
            IRoom room1 = new Room("Room 1");
            IRoom room2 = new Room("Room 2");
            IRoom room3 = new Room("Room 3");
            room1.AddAdjacentRoom(room2);
            room1.AddAdjacentRoom(room3);

            // Act
            List<IRoom> connectedRooms = room1.GetConnectedRooms();

            // Assert
            Assert.IsTrue(connectedRooms.Contains(room2));
            Assert.IsTrue(connectedRooms.Contains(room3));
            Assert.AreEqual(2, connectedRooms.Count);
        }
    }
}

