using System;
using System.IO;

namespace E02_Line_Numbers
{
    class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                var counter = 1;

                using (var writer=new StreamWriter("../../../output.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line==null)
                        {
                            break;
                        }
                        var counterLetters = 0;
                        var counterPunct = 0;

                        foreach (var character in line)
                        {
                            if (char.IsLetter(character))
                            {
                                counterLetters++;
                            }
                            else if (char.IsPunctuation(character))
                            {
                                counterPunct++;
                            }
                        }

                        writer.WriteLine($"Line{counter}: {line} ({counterLetters})({counterPunct})");

                        counter++;
                    }
                }
            }
        }
    }
}
