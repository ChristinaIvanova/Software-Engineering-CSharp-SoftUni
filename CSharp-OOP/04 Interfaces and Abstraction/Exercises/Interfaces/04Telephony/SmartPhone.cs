using _04Telephony.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04Telephony
{
    public class SmartPhone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }
    }
}
