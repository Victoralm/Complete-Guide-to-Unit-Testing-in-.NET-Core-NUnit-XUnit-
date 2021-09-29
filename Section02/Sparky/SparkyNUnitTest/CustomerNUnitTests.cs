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
        [Test]
        public void GreetAndCombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            var customer = new Customer();

            // Act
            string fullName = customer.GreetAndCombineNames("Ben", "Spark");

            // Assert
            Assert.AreEqual("Hello, Ben Spark", fullName);
            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(fullName, Does.Contain("Hello,")); // Case sensitive
            Assert.That(fullName, Does.Contain("hello,").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello")); // Case sensitive
            Assert.That(fullName, Does.EndWith("Spark")); // Case sensitive
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

            Assert.AreEqual("Hello, Ben Spark", customer.GreetMessage);
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(customer.GreetMessage, Does.Contain("Hello,")); // Case sensitive
            Assert.That(customer.GreetMessage, Does.Contain("hello,").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.StartWith("Hello")); // Case sensitive
            Assert.That(customer.GreetMessage, Does.EndWith("Spark")); // Case sensitive
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            // Arrange
            var customer = new Customer();

            // Act

            // Assert
            Assert.IsNull(customer.GreetMessage);
        }
    }
}
