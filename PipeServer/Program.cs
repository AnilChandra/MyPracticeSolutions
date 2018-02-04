using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace PipeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ByteTransmission();
        }
        static void ByteTransmission()
        {
            using (NamedPipeServerStream server =
                new NamedPipeServerStream("pipe1"))
            {
                server.WaitForConnection();
                Console.WriteLine("Connection Established");

                Console.WriteLine("Press Enter to write a byte");
                Console.ReadLine();

                server.WriteByte(111);
                Console.WriteLine("Server wrote byte into pipe");

                Console.WriteLine("Press enter to read incoming byte from client");
                Console.ReadLine();

                Console.WriteLine(server.ReadByte());

            }
            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
