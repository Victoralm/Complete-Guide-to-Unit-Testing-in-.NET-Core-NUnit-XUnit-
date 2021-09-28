using NUnit.Framework;
using Sparky;
using System;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            int result = calc.AddNumbers(10, 20);

            // Assert (Checking the results)
            Assert.AreEqual(30, result);
        }
    }
}
