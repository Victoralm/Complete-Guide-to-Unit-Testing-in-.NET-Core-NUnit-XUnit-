using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdraw(int balanceAfterWithdraw);
    }

    public class LogBook : ILogBook
    {
        public bool LogBalanceAfterWithdraw(int balanceAfterWithdraw)
        {
            if (balanceAfterWithdraw >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Personal note: The LogFakker class isn't a good practice either...
    //public class LogFakker : ILogBook
    //{
    //    public void Message(string message)
    //    {
    //    }
    //}
}
