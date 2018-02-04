using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullChecks
{
    public class PlayerDisplayer
    {
        

        public void Write(PlayerCharacter myPlayer)
        {
            Console.WriteLine(myPlayer.Name);
            int days = myPlayer.DaysSinceLastLogin ?? -1;

            if (myPlayer.DaysSinceLastLogin == null )
            {
                Console.WriteLine("No Value");
            }
            else
            {
                Console.WriteLine(myPlayer.DaysSinceLastLogin);
            }
        }

        
    }
}
