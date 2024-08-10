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
            const string name = "Walk to test";
            var soundCommand = new WalkToCommand(name);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            soundCommand.Execute();

            //Assert
            Assert.AreEqual("Walk to test\r\n", consoleOutput.ToString());
        }
    }
}
