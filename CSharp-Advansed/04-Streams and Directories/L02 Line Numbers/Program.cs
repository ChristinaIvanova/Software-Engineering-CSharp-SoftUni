namespace L02_Line_Numbers
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("Input.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    var countLines = 1;

                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        line = $"{countLines}. {line}";
                        writer.WriteLine(line);

                        countLines++;
                    }
                }
            }
        }
    }
}
