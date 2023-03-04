using GameServer.Sound;
using Microsoft.AspNetCore.Routing;
using System.Xml.Linq;

namespace GameServerUnitTests.SoundTests
{
    [TestClass]
    public class SoundTests
    {
        [TestMethod]
        public void Sound_Constructor_Sets_Properties_Correctly()
        {
            // Arrange
            int propagationDistance = 10;
            string name = "Test Sound";

            // Act
            Sound sound = new Sound(propagationDistance, name);

            // Assert
            Assert.AreEqual(propagationDistance, sound.PropagationDistance);
            Assert.AreEqual(name, sound.Name);
        }
    }
}
