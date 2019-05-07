using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E05_Directory_Traversal
{
    class Program
    {
        static void Main()
        {
            var path = Console.ReadLine();

            var dir = new DirectoryInfo(path);

            var allFiles = new Dictionary<string, List<FileInfo>>();

            foreach (var file in dir.GetFiles())
            {
                var extension = file.Extension;

                if (!allFiles.ContainsKey(extension))
                {
                    allFiles[extension] = new List<FileInfo>();
                }
                allFiles[extension].Add(file);
            }

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.txt";

            using (var writer = new StreamWriter(desktopPath))
            {
                foreach (var kvp in allFiles.OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key))
                {
                    var extension = kvp.Key;
                    var fileInfo = kvp.Value;

                    writer.WriteLine(extension);
                    foreach (var info in fileInfo)
                    {
                        var name = info.Name;
                        var size = info.Length / 1024;

                        writer.WriteLine($"--{name} - {size}kb");
                    }
                }
            }
        }
    }
}
