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

            // Runs all the asserts, doesn't stop on the first failutre
            Assert.Multiple(() => {
                Assert.AreEqual("Hello, Ben Spark", this._customer.GreetMessage);
                Assert.That(this._customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.That(this._customer.GreetMessage, Does.Contain("Hello,")); // Case sensitive
                Assert.That(this._customer.GreetMessage, Does.Contain("hello,").IgnoreCase);
                Assert.That(this._customer.GreetMessage, Does.StartWith("Hello")); // Case sensitive
                Assert.That(this._customer.GreetMessage, Does.EndWith("Spark")); // Case sensitive
                Assert.That(this._customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            // Arrange
            

            // Act

            // Assert
            Assert.IsNull(this._customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCostumer_ReturnDiscountInRange()
        {
            int result = this._customer.Discount;

            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            this._customer.GreetAndCombineNames("Ben", "");

            Assert.IsNotNull(this._customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(this._customer.GreetMessage));
        }
        
        [Test]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => this._customer.GreetAndCombineNames("", "Spark"));

            Assert.AreEqual("Empty first name...", exceptionDetails.Message);

            Assert.That(() => this._customer.GreetAndCombineNames("", "Spark"), Throws.ArgumentException.With.Message.EqualTo("Empty first name..."));


            // Checks oly if an Exception has been throwed
            Assert.Throws<ArgumentException>(() => this._customer.GreetAndCombineNames("", "Spark"));

            Assert.That(() => this._customer.GreetAndCombineNames("", "Spark"), Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            this._customer.OrderTotal = 10;
            var result = this._customer.GetCustomerDetails();

            Assert.That(result, Is.TypeOf<CustomerBasic>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicPlatinum()
        {
            this._customer.OrderTotal = 101;
            var result = this._customer.GetCustomerDetails();

            Assert.That(result, Is.TypeOf<CustomerPlatinum>());
        }
    }
}
