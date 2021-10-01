using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        int Discount { get; set; }
        int OrderTotal { get; set; }
        string GreetMessage { get; set; }
        bool IsPlatinum { get; set; }

        string GreetAndCombineNames(string firstName, string lastName);

        CustomerType GetCustomerDetails();
    }

        public class Customer : ICustomer
    {
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }

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
