using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E06_Full_Directory_Traversal
{
    class Program
    {
        static void Main()
        {
            var path = Console.ReadLine();

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            var extensionFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                if (!extensionFileInfo.ContainsKey(info.Extension))
                {
                    extensionFileInfo[info.Extension] = new List<FileInfo>();
                }

                extensionFileInfo[info.Extension].Add(info);
            }

            var pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.txt";

            using (var writer = new StreamWriter(pathToDesktop))
            {
                foreach (var kvp in extensionFileInfo.OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key))
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
