namespace L03_Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var words = new List<string>();

            using (var wordsReader = new StreamReader("../../../words.txt"))
            {
                while (true)
                {
                    var line = wordsReader.ReadLine();
                     
                    if (line == null)
                    {
                        break;
                    }

                    var splittedLine = line
                        .ToLower()
                        .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    words.AddRange(splittedLine);
                }
            }

            var wordsCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 0;
                }
            }

            using (var reader = new StreamReader("../../../text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var symbols = " ";
                    foreach (var charr in line)
                    {
                        if (char.IsPunctuation(charr) && charr != '\'')
                        {
                            symbols += charr;
                        }
                    }

                    var splittedLine = line
                        .ToLower()
                        .Split(symbols.ToCharArray()
                        , StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in splittedLine)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }
            wordsCount = wordsCount
                .OrderByDescending(x => x.Value)
               .ToDictionary(x => x.Key, x => x.Value);

            using (var writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var word in wordsCount)
                {
                    var line = $"{word.Key} - {word.Value}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}
