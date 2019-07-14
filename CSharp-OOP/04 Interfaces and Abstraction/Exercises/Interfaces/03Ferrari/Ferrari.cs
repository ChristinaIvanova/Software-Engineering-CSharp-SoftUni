using System;
using System.Collections.Generic;
using System.Text;

namespace _03Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Model => "488-Spider";

        public string Driver { get; private set; }

        public string Gas()
        {
            return "Brakes!";
        }

        public string PushBrakes()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Gas()}/{this.PushBrakes()}/{this.Driver}";
        }
    }
}
