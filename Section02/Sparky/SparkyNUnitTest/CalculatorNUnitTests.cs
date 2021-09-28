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
        
        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            var result = calc.IsOddNumber(6);

            // Assert (Checking the results)
            //Assert.AreEqual(false, result);
            //Assert.That(result, Is.EqualTo(false));
            //Assert.IsTrue(result);
            Assert.IsFalse(result);
        }
        
        [Test]
        [TestCase(21)]
        [TestCase(19)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int num)
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            var result = calc.IsOddNumber(num);

            // Assert (Checking the results)
            //Assert.AreEqual(true, result);
            //Assert.That(result, Is.EqualTo(true));
            //Assert.IsFalse(result);
            Assert.IsTrue(result);
        }
    }
}
