using Sparky;
using System;
using System.Collections.Generic;
using Xunit;

namespace SparkyNUnitTest
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            int result = calc.AddNumbers(10, 20);

            // Assert (Checking the results)
            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)] // 15.9
        [InlineData(5.43, 10.53)] // 15.96
        [InlineData(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            double result = calc.AddNumbersDouble(a, b);

            // Assert (Checking the results)
            Assert.Equal(15.9, result, 2); // Using precision value to check if the diference is at the decimal places
        }

        [Fact]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            var result = calc.IsOddNumber(6);

            // Assert (Checking the results)
            Assert.False(result);
        }

        [Theory]
        [InlineData(21)]
        [InlineData(19)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int num)
        {
            // Arrange (Test initialization)
            Calculator calc = new Calculator();

            // Act (Invoking needed methods)
            var result = calc.IsOddNumber(num);

            // Assert (Checking the results)
            Assert.True(result);
        }

        [Theory]
        [InlineData(20, false)]
        [InlineData(19, true)]
        public void IsOddNumber_InputNumber_ReturnTrueIffOdd(int num, bool expected)
        {
            Calculator calc = new Calculator();

            Assert.Equal(expected, calc.IsOddNumber(num));
        }

        [Fact]
        public void GetOddRange_InputMinAndMaxRange_ReturnValidOddNumberRange()
        {
            // Arrange (Test initialization)
            Calculator calculator = new Calculator();
            List<int> expectedOddRange = new() { 5, 7, 9 }; // 5 - 10

            // Act (Invoking needed methods)
            List<int> result = calculator.GetOddRange(5, 10);

            // Assert (Checking the results)
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, expectedOddRange);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result);
        }
    }
}
