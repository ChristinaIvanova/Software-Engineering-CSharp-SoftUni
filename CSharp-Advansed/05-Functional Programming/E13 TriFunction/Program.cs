namespace E13_TriFunction
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var length = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split();

            Func<string, int, bool> isLarger = (name, charsSum)
                => name.Sum(x => x) >= charsSum;

            Func<string[], Func<string, int, bool>, string> nameFilter =
                (inputNames, isLargerFilter)
                => inputNames.FirstOrDefault(x => isLargerFilter(x, length));

            var result = nameFilter(names, isLarger);
            Console.WriteLine(result);
        }
    }
}
