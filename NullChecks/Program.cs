using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullChecks
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new PlayerCharacter();
            player.Name = "Anil";
            PlayerDisplayer display = new PlayerDisplayer();
            display.Write(player);

            Console.ReadLine();
        }
    }
}
