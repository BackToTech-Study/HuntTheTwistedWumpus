using ConsoleClient.Commands;

namespace ConsoleClientUnitTests.CommandsTests
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
            ICommand command = commandFactory.CreateCommand<WalkToCommand>();

            //Assert
            Assert.IsInstanceOfType(command, typeof(WalkToCommand));
        }
    }
}
