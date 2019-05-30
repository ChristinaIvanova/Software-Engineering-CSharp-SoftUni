namespace L04_Merge_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string[] linesFirstFile = File.ReadAllLines("FileOne.txt");
            string[] linesSecondFile = File.ReadAllLines("FileTwo.txt");

            var resultText = new List<string>();

            var maxLenght = Math.Max(linesFirstFile.Length,linesSecondFile.Length);
            
            for (int i = 0; i < maxLenght; i++)
            {
                if (linesFirstFile.Length <= maxLenght)
                {
                    resultText.Add(linesFirstFile[i]);
                }
                if (linesSecondFile.Length <= maxLenght)
                {
                    resultText.Add(linesSecondFile[i]);
                }
            }

            File.WriteAllLines("MergedFile.txt", resultText);
        }
    }
}
