using System;
using System.IO;
using System.Linq;

namespace E01_Even_lines
{
    class Program
    {
        static void Main()
        {
            var specialSymbols = "-.,!?";
            var counter = 0;

            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }
                        
                        if (counter % 2 == 0)
                        {
                            var changedLine = string.Empty;

                            foreach (var character in line)
                            {
                                if (specialSymbols.Contains(character))
                                {
                                    changedLine += '@';
                                }
                                else
                                {
                                    changedLine += character;
                                }
                            }

                            var splittedLine = changedLine.Split().ToArray();

                            Array.Reverse(splittedLine);

                            writer.WriteLine(string.Join(" ", splittedLine));

                        }

                        counter++;
                    }
                }
            }
        }
    }
}
