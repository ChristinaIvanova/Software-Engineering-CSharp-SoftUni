using System;

namespace ME01_Data_types
{
    class Program
    {
        static void Main()
        {
            string dataType = Console.ReadLine();
            FindDataTypes(dataType);
        }

        private static void FindDataTypes(string dataType)
        {
            string data = Console.ReadLine();
            var result = 0.0;
            if (dataType == "int")
            {
                result = int.Parse(data) * 2;
                Console.WriteLine(result);
            }
            else if (dataType == "real")
            {
                result = double.Parse(data) * 1.5;
                Console.WriteLine($"{result:f2}");
            }
            else if (dataType == "string")
            {
                Console.WriteLine($"${data.ToString()}$");
            }
        }
    }
}
