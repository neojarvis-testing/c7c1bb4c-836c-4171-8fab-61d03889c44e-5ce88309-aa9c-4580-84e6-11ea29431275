using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp3.Exceptions
{
    public class AccountBalanceException : ApplicationException
    {
       public AccountBalanceException() { }

        public AccountBalanceException(string message) : base(message) { }

        public static AccountBalanceException With(Decimal targetValue)
        {
            return new AccountBalanceException($"Source account doesn't have enough fund to open account with amount {targetValue}");
        } 
    }
}