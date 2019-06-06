namespace _05DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please fill directory path:");

            var path = Console.ReadLine();

            var files = Directory.GetFiles(path, "*.*");

            var directoryInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo currentFile = new FileInfo(file);

                if (!directoryInfo.ContainsKey(currentFile.Extension))
                {
                    directoryInfo[currentFile.Extension] = new List<FileInfo>();
                }

                directoryInfo[currentFile.Extension].Add(currentFile);
            }

            var sortedDirInfo = directoryInfo
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

            var pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            using (var writer = new StreamWriter(pathToDesktop))
            {
                foreach (var kvp in sortedDirInfo)
                {
                    var ext = kvp.Key;
                    var info = kvp.Value;

                    writer.WriteLine(ext);
                    foreach (var fileInfo in info.OrderByDescending(x => x.Length))
                    {
                        var name = fileInfo.Name;
                        var size = fileInfo.Length / 1024;

                        writer.WriteLine($"--{name} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
