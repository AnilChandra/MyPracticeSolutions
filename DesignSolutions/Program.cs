using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DesignSolutions
{

    //class program to design facebook efficiently on diffrent machines
    //1. Get Machine id based on the personID
    //2. GO to that machineIndex
    //3. Fetch each friend based on the machine index
    //class Program
    //{

        
       public class Person
        {
            List<int> FriendIDs;
            private int persondID;
            public Person(int ID)
            {
                this.persondID = ID;
            }
           

            public int getID()
            {
                return persondID;
            }
            public void AddFriend(int ID)
            { 
              
            }
                   
        }

        public class Machine
        {
            public Dictionary<int, Person> persons = new Dictionary<int, Person>();
            public int MachineID;

            public Person getPersonWithID( int personID) 
            {

                return persons[personID];
            }
        
        }

        public class Server 
        {
            Dictionary<int, Machine> machines = new Dictionary<int , Machine>();
            Dictionary<int, int> personToMachineMap = new Dictionary<int, int>();

            public Machine getMachineWithID(int machineID) 
            {
                return machines[machineID];

            }
            public int getMachineIDForUser(int personID)
            {
               int machineID = personToMachineMap[personID];
               return machineID;
            }

            public Person getPersonWithID(int personID)
            { 
                int machineID = personToMachineMap[personID];
                Machine machine = getMachineWithID(machineID);
                return machine.getPersonWithID(personID);
            
            }
        
        }
        //static void Main(string[] args)
        //{
        //}
    }
//}
