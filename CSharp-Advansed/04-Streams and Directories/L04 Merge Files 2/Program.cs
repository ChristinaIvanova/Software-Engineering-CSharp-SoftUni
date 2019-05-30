namespace L04_Merge_Files_2
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var allText = File.ReadAllLines("FileOne.txt").ToList();
            allText.AddRange(File.ReadLines("FileTwo.txt"));

            allText.Sort();

            File.WriteAllLines("../../../MergedFile.txt", allText);
        }
    }
}
