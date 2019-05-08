using System;
using System.Linq;

namespace L03_Count_Uppercase_Words
{
    class Program
    {
        static void Main()
        {
            Func<string, bool> checker = n => char.IsUpper(n[0]);

            var words = Console.ReadLine().Split(new string[] { " " },
                          StringSplitOptions.RemoveEmptyEntries)
                               .Where(checker)
                               .ToArray();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

        }
    }
}
