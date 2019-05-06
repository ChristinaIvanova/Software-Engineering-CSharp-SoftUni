using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L05_Slice_File
{
    class Program
    {
        static void Main()
        {
            string destinationDirectory = "Resources/05. Slice File";

            string sourceFile = "Resources/05. Slice File/sliceMe.txt";

            int parts = 4;

            List<string> files = new List<string> { "Part-1.txt", "Part-2.txt ", "Part-3.txt ", "Part-4.txt" };

            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    using (var writer = new FileStream($"{destinationDirectory}/{files[i]}", FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while ((reader.Read(buffer, 0, buffer.Length)) == buffer.Length)
                        {
                            currentPieceSize += buffer.Length;

                            writer.Write(buffer, 0, buffer.Length);

                            if (currentPieceSize >= pieceSize)
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

