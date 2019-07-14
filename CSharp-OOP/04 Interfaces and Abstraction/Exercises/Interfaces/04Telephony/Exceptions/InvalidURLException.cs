using System;
using System.Collections.Generic;
using System.Text;

namespace _04Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string ExceptionMsg = "Invalid URL!";

        public InvalidURLException()
            :base(ExceptionMsg)
        {
        }
    }
}
