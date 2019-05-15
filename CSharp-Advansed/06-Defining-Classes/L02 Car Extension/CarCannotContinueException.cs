using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Car_Extension
{
    public class CarCannotContinueException : Exception
    {
        public CarCannotContinueException(string message)
            : base(message)
        {

        }
    }
}
