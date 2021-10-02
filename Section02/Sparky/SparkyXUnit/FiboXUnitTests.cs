using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class FiboXUnitTests
    {
        private Fibo _fibo;

        public FiboXUnitTests()
        {
            this._fibo = new Fibo();
        }

        [Theory]
        [InlineData(1)]
        public void GetFiboSeries_InputRange1_ReturPass(int range)
        {
            this._fibo.Range = range;
            List<int> fiboSeries = new() { 0 };

            Assert.NotEmpty(this._fibo.GetFiboSeries());
            Assert.Equal(this._fibo.GetFiboSeries().OrderBy(u => u), this._fibo.GetFiboSeries());
            Assert.True(this._fibo.GetFiboSeries().SequenceEqual(fiboSeries));
        }

        [Theory]
        [InlineData(6)]
        public void GetFiboSeries_InputRange6_ReturPass(int range)
        {
            this._fibo.Range = range;
            List<int> fiboSeries = new() { 0, 1, 1, 2, 3, 5 };

            Assert.Contains(3, this._fibo.GetFiboSeries());
            Assert.Equal(6, this._fibo.GetFiboSeries().Count);
            Assert.DoesNotContain(4, this._fibo.GetFiboSeries());
            Assert.True(this._fibo.GetFiboSeries().SequenceEqual(fiboSeries));
        }
    }
}
