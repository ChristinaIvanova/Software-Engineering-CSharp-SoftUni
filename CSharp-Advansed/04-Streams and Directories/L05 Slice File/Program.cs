namespace L05_Slice_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            var destinationDirectory = "04-Streams and Directories/L05 Slice File";

            var sourceFile = "../../../sliceMe.txt";

            int parts = 4;

            var files = new List<string> { "Part-1.txt", "Part-2.txt ", "Part-3.txt ", "Part-4.txt" };

            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPiece = 0;

                    using (var writer = new FileStream($"{destinationDirectory}/{files[i]}",
                        FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while (reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            currentPiece += buffer.Length;

                            writer.Write(buffer, 0, buffer.Length);

                            if (currentPiece >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
