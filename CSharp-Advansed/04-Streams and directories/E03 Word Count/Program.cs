using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E03_Word_Count
{
    class Program
    {
        static void Main()
        {
            var words = new List<string>();
            using (var wordReader = new StreamReader("../../../words.txt"))
            {
                while (true)
                {
                    var line = wordReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var splittedLine = line.Split(" ",
                        StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
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
                        .Split(symbols.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in splittedLine)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }

            var sortedDictionary = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            

            using (var readerResult = new StreamReader("../../../expectedResult.txt"))
            {
                bool isSame = true;

                foreach (var kvp in sortedDictionary)
                {
                    var output = $"{kvp.Key} - {kvp.Value}";
                    var line = readerResult.ReadLine();

                    if (output != line)
                    {
                        isSame = false;
                        break;
                    }
                }

                if (isSame)
                {
                    Console.WriteLine("Result after comparing: Files Are Identical");
                }
                else
                {
                    Console.WriteLine("Result after comparing: Files Are NOT Identical");
                }
            }

            using (var writerResult=new StreamWriter("../../../actualResult.txt"))
            {

                foreach (var kvp in sortedDictionary)
                {
                    var output = $"{kvp.Key} - {kvp.Value}";
                    writerResult.WriteLine(output);
                }
            }
        }
    }
}
