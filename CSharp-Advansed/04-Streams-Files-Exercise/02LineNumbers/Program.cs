namespace _02LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var textPath = "../../../text.txt";
            var outputPath = "../../../output.txt";

            var text = File.ReadAllLines(textPath).ToArray();
            
            for (int i = 0; i < text.Length; i++)
            {
                var line = text[i];
                
                var countLetters = line.Count(char.IsLetter);

                var countPunctuations = line.Count(char.IsPunctuation);

                File.AppendAllText(outputPath, $"Line {i + 1}: {line} ({countLetters})({countPunctuations}){Environment.NewLine}");
            }
        }
    }
}
