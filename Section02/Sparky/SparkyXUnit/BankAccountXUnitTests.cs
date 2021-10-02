using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    internal class BankAccountXUnitTests
    {
        private BankAccount _bankAccount;
        [SetUp]
        public void Setup()
        {
            
        }

        //[Test]
        //public void DepositLogFakker_Add100_ReturnTrue()
        //{
        //    BankAccount bankAccount = new(new LogFakker());
        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        //}

        [Test]
        public void DepositLog_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        public void Withdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);

            Assert.IsTrue(result);
        }
        
        [Test]
        [TestCase(200, 300)]
        public void Withdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            // Implies that if "x < 0" returns false
            logMock.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);
            // Imperatively returning false when "x < 0" (unnecessary)
            //logMock.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x < 0))).Returns(false);
            //logMock.Setup(u => u.LogBalanceAfterWithdraw(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);

            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();

            string desiredOutput = "hello";

            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            // Returns a null object, cause it's only configured to "Hi" string
            //logMock.Setup(u => u.MessageWithReturnStr("Hi")).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("HEllO"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();

            string desiredOutput = "hello";

            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";

            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();

            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Test]
        public void BankLogDummy_GetAndSetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("warning");

            // Can't assign MOQ properties this way...
            //logMock.Object.LogSeverity = 100;
            // Butt this way
            logMock.SetupAllProperties();
            logMock.Object.LogSeverity = 100;
            logMock.Object.LogType = "warning";

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));


            // Callbacks
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Returns(true).Callback((string str) => logTemp += str);

            logMock.Object.LogToDb("Ben");

            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));
            
            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++)
                .Returns(true)
                .Callback(() => counter++);

            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");

            Assert.That(counter, Is.EqualTo(9));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            //BankAccount bankAccount = new BankAccount(logMock.Object);
            BankAccount bankAccount = new (logMock.Object);

            bankAccount.Deposit(100);

            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));


            // Verification
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
        }
    }
}
