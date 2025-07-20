using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingFrontendApp.Tests
{
    [TestClass]
    public class DemoTests
    {
        [TestMethod]
        public void TwoPlusTwo_EqualsFour()
        {
            // Arrange
            int a = 2, b = 2;

            // Act
            int sum = a + b;

            // Assert
            Assert.AreEqual(4, sum, "2 + 2 should equal 4");
        }
    }
}
