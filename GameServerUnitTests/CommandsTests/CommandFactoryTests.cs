using GameServer.Commands;

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

            //Act
            ICommand command = commandFactory.CreateCommand<MakeSoundCommand>();

            //Assert
            Assert.IsInstanceOfType(command, typeof(MakeSoundCommand));
        }
    }
}
