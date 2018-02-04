using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace PipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ByteTransmission();
        }
        static void ByteTransmission()
        {
            using (NamedPipeClientStream client =
                new NamedPipeClientStream("pipe1"))
            {
                Console.WriteLine("Press enter to connect to server ");
                Console.ReadLine();

                client.Connect();
                Console.WriteLine("connection established to server ");

                Console.WriteLine("Press enter to read byte written by server ");
                Console.ReadLine();

                Console.WriteLine(client.ReadByte());
            }
            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
