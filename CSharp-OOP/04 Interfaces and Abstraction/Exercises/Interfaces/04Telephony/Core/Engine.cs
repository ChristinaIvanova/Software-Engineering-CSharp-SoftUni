using _04Telephony.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04Telephony.Core
{
    public class Engine
    {
        private SmartPhone smartPhone;

        public Engine()
        {
            this.smartPhone = new SmartPhone();
        }

        public void Run()
        {
            var numbers = Console.ReadLine()
                .Split(" ");

            var urls = Console.ReadLine()
                .Split(" ");

            CallNumbers(numbers, smartPhone);

            BrowseInternet(urls, smartPhone);
        }

        private static void BrowseInternet(string[] urls, SmartPhone smartPhone)
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(url));
                }
                catch (InvalidURLException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }

        private static void CallNumbers(string[] numbers, SmartPhone smartPhone)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(smartPhone.Call(number));
                }
                catch (InvalidPhoneNumberException msg)
                {

                    Console.WriteLine(msg.Message); ;
                }
            }
        }
    }
}
