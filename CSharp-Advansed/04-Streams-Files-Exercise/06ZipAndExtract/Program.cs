namespace _06ZipAndExtract
{
    using System;
    using System.IO.Compression;

    class Program
    {
        static void Main()
        {
            var fileFolderPath = "./";
            var targetPath = "../../../result.zip";

            ZipFile.CreateFromDirectory(fileFolderPath, targetPath);

            ZipFile.ExtractToDirectory(targetPath, "../../../extractedZip");
        }
    }
}
