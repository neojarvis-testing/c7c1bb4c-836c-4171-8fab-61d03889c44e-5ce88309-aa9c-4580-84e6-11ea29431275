using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp3.Exceptions
{
    public class InvalidValueTypeException : ApplicationException
    {
       public InvalidValueTypeException() { }

        public InvalidValueTypeException(string message) : base(message) { }

        public static InvalidValueTypeException WithType(string type)
        {
            return new InvalidValueTypeException($"Invalid Value : {type} is invalid");
        } 
    }
}