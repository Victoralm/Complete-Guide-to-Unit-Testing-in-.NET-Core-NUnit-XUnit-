using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            this._customer = new Customer();
        }

        [Test]
        public void GreetAndCombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            

            // Act
            string fullName = this._customer.GreetAndCombineNames("Ben", "Spark");

            // Assert
            Assert.AreEqual("Hello, Ben Spark", fullName);
            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(fullName, Does.Contain("Hello,")); // Case sensitive
            Assert.That(fullName, Does.Contain("hello,").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello")); // Case sensitive
            Assert.That(fullName, Does.EndWith("Spark")); // Case sensitive
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

            Assert.AreEqual("Hello, Ben Spark", this._customer.GreetMessage);
            Assert.That(this._customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(this._customer.GreetMessage, Does.Contain("Hello,")); // Case sensitive
            Assert.That(this._customer.GreetMessage, Does.Contain("hello,").IgnoreCase);
            Assert.That(this._customer.GreetMessage, Does.StartWith("Hello")); // Case sensitive
            Assert.That(this._customer.GreetMessage, Does.EndWith("Spark")); // Case sensitive
            Assert.That(this._customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            // Arrange
            

            // Act

            // Assert
            Assert.IsNull(this._customer.GreetMessage);
        }
    }
}
