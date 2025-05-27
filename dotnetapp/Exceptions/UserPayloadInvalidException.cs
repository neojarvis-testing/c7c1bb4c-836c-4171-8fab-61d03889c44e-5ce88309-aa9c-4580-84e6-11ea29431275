using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Exceptions
{
    public class UserPayloadInvalidException : ApplicationException
    {
        public UserPayloadInvalidException() { }

        public UserPayloadInvalidException(string message) : base(message) { }
    }
}