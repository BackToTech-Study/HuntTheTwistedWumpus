using ConsoleClient.Commands;
using Moq;

namespace ConsoleClientUnitTests.CommandsTests
{
    [TestClass]
    public class CommandRepositoryTests
    {
        [TestMethod]
        public void Add_ShouldAddCommandToList()
        {
            // Arrange
            var commandRepository = new CommandRepository();
            var command = new Mock<ICommand>().Object;

            // Act
            commandRepository.Add(command);

            // Assert
            CollectionAssert.Contains(commandRepository.GetAllCommands(), command);
        }

        [TestMethod]
        public void GetAllCommands_ShouldReturnAllCommands()
        {
            // Arrange
            var commandRepository = new CommandRepository();
            var firstCommand = new Mock<ICommand>().Object;
            var secondCommand = new Mock<ICommand>().Object;

            commandRepository.Add(firstCommand);
            commandRepository.Add(secondCommand);

            // Act
            var commands = commandRepository.GetAllCommands();

            // Assert
            Assert.AreEqual(2, commands.Count);
            CollectionAssert.Contains(commands, firstCommand);
            CollectionAssert.Contains(commands, secondCommand);
        }
    }
}
