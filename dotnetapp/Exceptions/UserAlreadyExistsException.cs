using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Exceptions
{
    public class UserAlreadyExistsException : ApplicationException
    {
        public UserAlreadyExistsException() { }

        public UserAlreadyExistsException(string message) : base(message) { }

        public static UserAlreadyExistsException WithUsername(string username)
        {
            return new UserAlreadyExistsException($"User with  username: {username} already exists");
        }

        public static UserAlreadyExistsException WithEmail(string email)
        {
            return new UserAlreadyExistsException($"User with  email: {email} already exists");
        }
    }
}