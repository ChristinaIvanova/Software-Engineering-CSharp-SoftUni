namespace _04CopyBinaryFile
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            var picPath = "../../../copyMe.png";
            var copyPath = "../../../copied.png";

            using (var reader = new FileStream(picPath, FileMode.Open))
            {
                using (var writer = new FileStream(copyPath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];

                        var byteSize = reader.Read(buffer, 0, buffer.Length);

                        if (byteSize == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, byteSize);
                    }
                }
            }
        }
    }
}
