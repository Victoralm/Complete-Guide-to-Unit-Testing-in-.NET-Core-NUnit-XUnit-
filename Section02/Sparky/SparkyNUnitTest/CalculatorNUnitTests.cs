﻿using NUnit.Framework;
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
        [TestCase(5.4, 10.5)] // 15.9
        [TestCase(5.43, 10.53)] // 15.96
        [TestCase(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            double result = calc.AddNumbersDouble(a, b);

            // Assert (Checking the results)
            // Assert.AreEqual(15.9, result, 1); // Using delta value to check if the diference is at maximmum 1 (Between 15.9 and 16.9)
            Assert.AreEqual(15.9, result, .1); // Using delta value to check if the diference is at maximmum 0.1 (Between 15.8 and 16.0)
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

        [Test]
        [TestCase(20, ExpectedResult = false)]
        [TestCase(19, ExpectedResult = true)]
        public bool IsOddNumber_InputNumber_ReturnTrueIffOdd(int num)
        {
            Calculator calc = new Calculator();
            return calc.IsOddNumber(num);
        }


    }
}
