using System;
using System.Collections.Generic;
using System.Text;

namespace _04Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string ExceptionMsg = "Invalid number!";

        public InvalidPhoneNumberException()
            :base(ExceptionMsg)
        {
        }
    }
}
