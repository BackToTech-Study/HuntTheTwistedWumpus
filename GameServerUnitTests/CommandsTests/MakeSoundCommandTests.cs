using GameServer.Commands;
using GameServer.Room;
using GameServer.Sound;
using Moq;
using System.Reflection;

namespace GameServerUnitTests.CommandsTests
{
    [TestClass]
    public class MakeSoundCommandTests
    {
        [TestMethod]
        public void Execute_SoundPropagatedToConnectedRooms()
        {
            // Arrange
            var sound = new Sound(1, "TestSound");
            var roomMock1 = new Mock<Room>("1");
            var roomMock2 = new Mock<Room>("2");
            var roomMock3 = new Mock<Room>("3");


            roomMock1.Object.AddAdjacentRoom(roomMock2.Object);
            roomMock1.Object.AddAdjacentRoom(roomMock3.Object);

            var makeSoundCommand = new MakeSoundCommand(sound, roomMock1.Object);

            // Act
            makeSoundCommand.Execute();

            // Assert
            Assert.AreEqual(roomMock1.Object.Sound, sound);
            Assert.AreEqual(roomMock2.Object.Sound, sound);
            Assert.AreEqual(roomMock3.Object.Sound, sound);
        }

        [TestMethod]
        public void Execute_SoundNotPropagatedIfPropagationHasAlreadyOccurred()
        {
            // Arrange
            var sound = new Sound(1, "TestSound");
            var roomMock = new Mock<IRoom>();
            var makeSoundCommand = new MakeSoundCommand(sound, roomMock.Object);

            // Set _hasPropagated to true to simulate that propagation has already occurred
            var hasPropagatedField = typeof(MakeSoundCommand).GetField("_hasPropagated", BindingFlags.NonPublic | BindingFlags.Static);
            hasPropagatedField.SetValue(null, true);

            // Act
            makeSoundCommand.Execute();

            // Assert
            roomMock.Verify(room => room.ReceiveSound(sound), Times.Never);
        }

        [TestMethod]
        public void PropagateSound_SoundPropagatedToAdjacentRooms_SoundPropagatedToConnectedRooms()
        {
            // Arrange
            var sound = new Sound(1, "TestSound");
            var roomMock1 = new Mock<Room>("1");
            var roomMock2 = new Mock<Room>("2");
            var roomMock3 = new Mock<Room>("3");


            roomMock1.Object.AddAdjacentRoom(roomMock2.Object);
            roomMock1.Object.AddAdjacentRoom(roomMock3.Object);

            var makeSoundCommand = new MakeSoundCommand(sound, roomMock1.Object);

            // Act
            makeSoundCommand.PropagateSound(roomMock1.Object, sound);

            // Assert
            Assert.AreEqual(roomMock1.Object.Sound, sound);
            Assert.AreEqual(roomMock2.Object.Sound, sound);
            Assert.AreEqual(roomMock3.Object.Sound, sound);
        }
    }
}
