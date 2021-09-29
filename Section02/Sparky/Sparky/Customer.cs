using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int Discount = 15;
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Empty first name...");

            GreetMessage =  $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new CustomerBasic();
            }
            return new CustomerPlatinum();
        }
    }

    public class CustomerType { }
    public class CustomerBasic : CustomerType { }
    public class CustomerPlatinum : CustomerType { }
}
