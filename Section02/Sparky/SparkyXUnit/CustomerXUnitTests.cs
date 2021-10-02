using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private Customer _customer;

        public CustomerXUnitTests()
        {
            this._customer = new Customer();
        }

        [Fact]
        public void GreetAndCombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange


            // Act
            string fullName = this._customer.GreetAndCombineNames("Ben", "Spark");

            // Assert
            Assert.Equal("Hello, Ben Spark", fullName);
            Assert.Contains("Hello,", fullName); // Case sensitive
            Assert.Contains("Hello,".ToLower(), fullName.ToLower()); // Case insensitive
            Assert.StartsWith("Hello", fullName); // Case sensitive
            Assert.EndsWith("Spark", fullName); // Case sensitive
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            // Arrange


            // Act

            // Assert
            Assert.Null(this._customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCostumer_ReturnDiscountInRange()
        {
            int result = this._customer.Discount;

            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            this._customer.GreetAndCombineNames("Ben", "");

            Assert.NotNull(this._customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(this._customer.GreetMessage));
        }

        [Fact]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => this._customer.GreetAndCombineNames("", "Spark"));

            Assert.Equal("Empty first name...", exceptionDetails.Message);


            // Checks oly if an Exception has been throwed
            Assert.Throws<ArgumentException>(() => this._customer.GreetAndCombineNames("", "Spark"));
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            this._customer.OrderTotal = 10;
            var result = this._customer.GetCustomerDetails();

            Assert.IsType<CustomerBasic>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicPlatinum()
        {
            this._customer.OrderTotal = 101;
            var result = this._customer.GetCustomerDetails();

            Assert.IsType<CustomerPlatinum>(result);
        }
    }
}
