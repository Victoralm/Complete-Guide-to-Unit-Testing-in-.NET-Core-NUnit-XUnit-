using System;

namespace Sparky
{
    public class Calculator
    {
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }
        
        public double AddNumbersDouble(double a, double b)
        {
            return a + b;
        }

        public bool IsOddNumber(int num)
        {
            return num % 2 != 0;
        }
    }
}
