namespace E01_Generic_Box_of_String
{
    using System;

    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var content = Console.ReadLine();

                var boxOfString = new Box<string>(content);
                Console.WriteLine(boxOfString);
            }
        }
    }
}
