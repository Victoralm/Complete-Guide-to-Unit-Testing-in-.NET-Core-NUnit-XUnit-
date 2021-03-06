using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        private int _balance;
        private readonly ILogBook _logBook;

        // Injecting ILogBook as a dependency
        public BankAccount(ILogBook logBook)
        {
            this._logBook = logBook;
            this._balance = 0;
        }

        public bool Deposit(int amount)
        {
            this._logBook.Message("Deposit invoked");
            this._logBook.Message("Test");
            this._logBook.LogSeverity = 101;
            var temp = this._logBook.LogSeverity;
            this._balance += amount;
            return true;
        }
        
        public bool Withdraw(int amount)
        {
            if(amount <= this._balance)
            {
                this._logBook.LogToDb($"Withdraw ammount: {amount}");
                this._balance -= amount;
                return this._logBook.LogBalanceAfterWithdraw(this._balance);
            }

            return this._logBook.LogBalanceAfterWithdraw(this._balance - amount);
        }

        public int GetBalance()
        {
            return this._balance;
        }
    }
}
