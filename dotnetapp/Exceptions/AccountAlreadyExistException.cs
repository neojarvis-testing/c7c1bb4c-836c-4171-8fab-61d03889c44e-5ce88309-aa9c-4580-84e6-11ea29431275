using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Exceptions
{
    public class AccountAlreadyExistException : ApplicationException
    {
        public AccountAlreadyExistException() { }

        public AccountAlreadyExistException(string message) : base(message) { }

        public static AccountAlreadyExistException WithUserId(int userId)
        {
            return new AccountAlreadyExistException($"Account with  userId: {userId} already exists");
        }
    }
}