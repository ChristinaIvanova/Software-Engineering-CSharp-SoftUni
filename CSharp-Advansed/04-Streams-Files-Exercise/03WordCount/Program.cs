namespace _03WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var textPath = "../../../text.txt";
            var wordsPath = "../../../words.txt";

            //in case of more than one word per line
            var inputWords = File.ReadAllText(wordsPath);
            var words = inputWords
                .ToLower()
                .Split(new [] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsDetails = DictionaryOfWords(words);

            var text = File.ReadAllText(textPath);

            var clearText = GetTextWithoutPunctuation(text);

            foreach (var word in clearText)
            {
                if (wordsDetails.ContainsKey(word))
                {
                    wordsDetails[word]++;
                }
            }

            var actualResultPath = "../../../actualResult.txt";
            var expectedResultPath = "../../../expectedResult.txt";

            foreach (var kvp in wordsDetails)
            {
                File.AppendAllText(actualResultPath, $"{kvp.Key} - {kvp.Value}{Environment.NewLine}");
            }

            var sortedActualResults = wordsDetails
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            var expectedResult = File.ReadAllLines(expectedResultPath);
            var expectedWordsResults = new Dictionary<string, int>();

            foreach (var line in expectedResult)
            {
                var wordsArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var word = wordsArgs[0];
                var wordCount = int.Parse(wordsArgs[2]);

                expectedWordsResults.Add(word, wordCount);
            }

            var isSame = sortedActualResults.SequenceEqual(expectedWordsResults);

            if (isSame)
            {
                Console.WriteLine("Result after comparing sorted actualResult.txt and expectedResult.txt : Identical values");
            }
            else
            {
                Console.WriteLine("Result after comparing sorted actualResult.txt and expectedResult.txt : NOT identical values");
            }
        }

        private static Dictionary<string, int> DictionaryOfWords(string[] words)
        {
            var wordsDetails = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsDetails[word] = 0;
            }

            return wordsDetails;
        }

        private static string[] GetTextWithoutPunctuation(string text)
        {
            var puncSymbols = " ";

            foreach (var charr in text)
            {
                if (char.IsPunctuation(charr) && charr != '\'')
                {
                    puncSymbols += charr;
                }
            }

            var textWithoutPunc = text
                 .ToLower()
                 .Split(puncSymbols.ToCharArray(),
                 StringSplitOptions.RemoveEmptyEntries);

            return textWithoutPunc;
        }
    }
}
