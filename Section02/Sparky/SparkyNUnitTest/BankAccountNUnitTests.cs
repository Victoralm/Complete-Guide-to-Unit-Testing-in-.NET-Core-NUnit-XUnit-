using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    internal class BankAccountNUnitTests
    {
        private BankAccount _bankAccount;
        [SetUp]
        public void Setup()
        {
            this._bankAccount = new(new LogFakker());
        }

        [Test]
        public void Deposit_Add100_ReturnTrue()
        {
            var result = this._bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(this._bankAccount.GetBalance, Is.EqualTo(100));
        }

    }
}
