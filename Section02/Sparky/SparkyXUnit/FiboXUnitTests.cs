using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    class FiboXUnitTests
    {
        private Fibo _fibo;

        [SetUp]
        public void Setup()
        {
            this._fibo = new Fibo();
        }

        [Test]
        [TestCase(1)]
        public void GetFiboSeries_InputRange1_ReturPass(int range)
        {
            this._fibo.Range = range;
            List<int> fiboSeries = new() { 0 };

            Assert.That(this._fibo.GetFiboSeries(), Is.Not.Empty);
            Assert.That(this._fibo.GetFiboSeries(), Is.Ordered);
            Assert.That(this._fibo.GetFiboSeries(), Is.EquivalentTo(fiboSeries));
        }

        [Test]
        [TestCase(6)]
        public void GetFiboSeries_InputRange6_ReturPass(int range)
        {
            this._fibo.Range = range;
            List<int> fiboSeries = new() { 0, 1, 1, 2, 3, 5 };

            Assert.That(this._fibo.GetFiboSeries(), Does.Contain(3));
            Assert.That(this._fibo.GetFiboSeries().Count, Is.EqualTo(6));
            Assert.That(this._fibo.GetFiboSeries(), Has.No.Member(4));
            Assert.That(this._fibo.GetFiboSeries(), Is.EquivalentTo(fiboSeries));
        }
    }
}
