using GameServer.Commands;
using GameServer.Messages;
using GameServer.Caverns;

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

            //Act
            ICommand command = commandFactory.CreateCommand<MakeSoundCommand, Sound>(sound);

            //Assert
            Assert.IsInstanceOfType(command, typeof(MakeSoundCommand));
        }
    }
}
