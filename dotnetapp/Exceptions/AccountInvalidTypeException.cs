using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Exceptions
{
    public class AccountInvalidTypeException : ApplicationException
    {
        public AccountInvalidTypeException() { }

        public AccountInvalidTypeException(string message) : base(message) { }

        public static AccountInvalidTypeException WithType(string type)
        {
            return new AccountInvalidTypeException($"Account type: {type} is invalid");
        }
    }
}