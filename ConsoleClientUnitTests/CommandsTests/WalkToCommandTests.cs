using ConsoleClient.Commands;

namespace ConsoleClientUnitTests.CommandsTests
{
    [TestClass]
    public class WalkToCommandTests
    {
        [TestMethod]
        public void TestMethod()
        {
            // Arrange
            var soundCommand = new WalkToCommand();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            soundCommand.Execute();

            //Assert
            Assert.AreEqual("Walk to cave placeholder\r\n", consoleOutput.ToString());
        }
    }
}
