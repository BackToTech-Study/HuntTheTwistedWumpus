using GameServer.Commands;
using Moq;

namespace GameServerUnitTests.CommandsTests
{
    [TestClass]
    public class MakeSoundCommandTests
    {
        [TestMethod]
        public void Execute_ShouldCallExecuteMethod()
        {
            // Arrange
            var soundCommand = new MakeSoundCommand();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            soundCommand.Execute();

            //Assert
            Assert.AreEqual("Make sound placeholder\r\n", consoleOutput.ToString());
        }
    }
}
