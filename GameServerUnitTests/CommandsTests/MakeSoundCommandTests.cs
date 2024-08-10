using GameServer.Caverns;
using GameServer.Commands;
using GameServer.Messages;
using Moq;

namespace GameServerUnitTests.CommandsTests
{
    [TestClass]
    public class MakeSoundCommandTests
    {
        [TestMethod]
        public void Execute_SoundPropagatedToConnectedRooms()
        {
            // Arrange
            var initialPropagationDistance = 2;
            var sound = new Sound(initialPropagationDistance, "TestSound");
            var roomMock1 = new Mock<Room>("1");
            var testSoundReceiver1 = new SoundSensibleTestObjects();
            roomMock1.Object.SoundSensibleObjects.Add(testSoundReceiver1);

            var roomMock2 = new Mock<Room>("2");
            var testSoundReceiver2 = new SoundSensibleTestObjects();
            roomMock2.Object.SoundSensibleObjects.Add(testSoundReceiver2);

            var roomMock3 = new Mock<Room>("3");
            var testSoundReceiver3 = new SoundSensibleTestObjects();
            roomMock3.Object.SoundSensibleObjects.Add(testSoundReceiver3);            


            roomMock1.Object.AddAdjacentRoom(roomMock2.Object);
            roomMock1.Object.AddAdjacentRoom(roomMock3.Object);

            var makeSoundCommand = new MakeSoundCommand(sound);

            // Act
            makeSoundCommand.Execute(roomMock1.Object);

            // Assert
            Assert.IsTrue(testSoundReceiver1.ReceivedSounds.Any());
            Assert.IsTrue(testSoundReceiver2.ReceivedSounds.Any());
            Assert.IsTrue(testSoundReceiver3.ReceivedSounds.Any());

            Assert.AreEqual(sound.Name, testSoundReceiver1.ReceivedSounds.First().Name);
            Assert.AreEqual(sound.Name, testSoundReceiver2.ReceivedSounds.First().Name);
            Assert.AreEqual(sound.Name, testSoundReceiver3.ReceivedSounds.First().Name);

            Assert.AreEqual(initialPropagationDistance-1, testSoundReceiver1.ReceivedSounds.First().PropagationDistance);
            Assert.AreEqual(initialPropagationDistance-2, testSoundReceiver2.ReceivedSounds.First().PropagationDistance);
            Assert.AreEqual(initialPropagationDistance-2, testSoundReceiver3.ReceivedSounds.First().PropagationDistance);            
        }

        [TestMethod]
        public void Execute_PlaySoundNoPropagation()
        {
            // Arrange
            var initialPropagationDistance = 1;
            var sound = new Sound(initialPropagationDistance, "TestSound");
            var roomMock1 = new Mock<Room>("1");
            var testSoundReceiver1 = new SoundSensibleTestObjects();
            roomMock1.Object.SoundSensibleObjects.Add(testSoundReceiver1);

            var roomMock2 = new Mock<Room>("2");
            var testSoundReceiver2 = new SoundSensibleTestObjects();
            roomMock2.Object.SoundSensibleObjects.Add(testSoundReceiver2);

            var roomMock3 = new Mock<Room>("3");
            var testSoundReceiver3 = new SoundSensibleTestObjects();
            roomMock3.Object.SoundSensibleObjects.Add(testSoundReceiver3);            


            roomMock1.Object.AddAdjacentRoom(roomMock2.Object);
            roomMock1.Object.AddAdjacentRoom(roomMock3.Object);

            var makeSoundCommand = new MakeSoundCommand(sound);

            // Act
            makeSoundCommand.Execute(roomMock1.Object);

            // Assert
            Assert.IsTrue(testSoundReceiver1.ReceivedSounds.Any());
            Assert.IsFalse(testSoundReceiver2.ReceivedSounds.Any());
            Assert.IsFalse(testSoundReceiver3.ReceivedSounds.Any());

            Assert.AreEqual(sound.Name, testSoundReceiver1.ReceivedSounds.First().Name);

            Assert.AreEqual(initialPropagationDistance-1, testSoundReceiver1.ReceivedSounds.First().PropagationDistance);         
        }

        [TestMethod]
        public void Execute_SoundNotPropagatedIfPropagationHasAlreadyOccurred()
        {
            // Arrange
            var initialPropagationDistance = 0;
            var sound = new Sound(initialPropagationDistance, "TestSound");
            var roomMock1 = new Mock<Room>("1");
            var testSoundReceiver1 = new SoundSensibleTestObjects();
            roomMock1.Object.SoundSensibleObjects.Add(testSoundReceiver1);

            var roomMock2 = new Mock<Room>("2");
            var testSoundReceiver2 = new SoundSensibleTestObjects();
            roomMock2.Object.SoundSensibleObjects.Add(testSoundReceiver2);

            var roomMock3 = new Mock<Room>("3");
            var testSoundReceiver3 = new SoundSensibleTestObjects();
            roomMock3.Object.SoundSensibleObjects.Add(testSoundReceiver3);            


            roomMock1.Object.AddAdjacentRoom(roomMock2.Object);
            roomMock1.Object.AddAdjacentRoom(roomMock3.Object);

            var makeSoundCommand = new MakeSoundCommand(sound);

            // Act
            makeSoundCommand.Execute(roomMock1.Object);

            // Assert
            Assert.IsFalse(testSoundReceiver1.ReceivedSounds.Any());
            Assert.IsFalse(testSoundReceiver2.ReceivedSounds.Any());
            Assert.IsFalse(testSoundReceiver3.ReceivedSounds.Any());
        }
    }
}
