using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Exceptions
{
    public class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException() { }

        public AccountNotFoundException(string message) : base(message) { }

        public static AccountNotFoundException WithId(int id)
        {
            return new AccountNotFoundException($"Account with Id: {id} not found");
        }
    }
}