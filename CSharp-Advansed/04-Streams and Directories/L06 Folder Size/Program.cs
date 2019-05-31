namespace L06_Folder_Size
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] filesInDir = Directory.GetFiles("../../../TestFolder");

            double totalSize = 0;

            foreach (string file in filesInDir)
            {
                FileInfo fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            totalSize = totalSize / 1024 / 1024;

            File.WriteAllText("output.txt", totalSize.ToString());
        }
    }
}
