using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class ProductXUnitTests
    {
        [Fact]
        public void GetPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var product = new Product() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.Equal(40, result);
        }

        /**
         * Not a good aproach!
         * The interface and more code was added only to be used within the MOQ test...
         * Just a show off the Mocking skill example.
         */
        [Fact]
        public void GetPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            var product = new Product() { Price = 50 };

            var result = product.GetPrice(customer.Object);

            Assert.Equal(40, result);
        }
    }
}
