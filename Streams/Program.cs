using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.Create(@"D:\files\testfile.txt"))
            {
                long pos = fs.Position;
                fs.Position = 7;
                byte[] arrbytes = {101,110};
                fs.Write(arrbytes, 0, arrbytes.Length);
                
                pos = fs.Position;

                byte[] readdata = ReadBytes(fs);
            }

        }

        static byte[] ReadBytes(Stream stream)
        {
            byte[] dataToRead = new byte[stream.Length];

            int totalBytesRead = 0;

            return dataToRead;
        }
    }
}
