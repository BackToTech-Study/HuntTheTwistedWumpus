using GameServer.Commands;
using GameServer.Room;
using GameServer.Sound;

namespace GameServerUnitTests.CommandsTests
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void CreateCommand_ReturnsInstanceOfGivenType()
        {
            //Arrange
            var commandFactory = new CommandFactory();
            Sound sound = new Sound(1, "test");
            IRoom room = new Room("TestRoom");

            //Act
            ICommand command = commandFactory.CreateCommand<MakeSoundCommand, Sound, IRoom>(sound, room);

            //Assert
            Assert.IsInstanceOfType(command, typeof(MakeSoundCommand));
        }
    }
}
