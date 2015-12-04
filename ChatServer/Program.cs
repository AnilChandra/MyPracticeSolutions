using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Server
    {
        private Boolean serverAvailable;
        private Boolean serverNotAvailable;

        public Boolean ServerAvilable
        {
            get { return serverAvailable; }
            set { serverAvailable = value; }
        }

        public Boolean ServerNotAvailable
        {
            get { return serverNotAvailable }
            set { serverNotAvailable = value; }
        
        }
        HashSet<int, Machine> machines = new HashSet<int, Machine>();
    }

    public class Machine
    { 
    
    
    }

    class Client
    {

        private string sendMsg;
        private string rcvMsg;

        public String SendMsg
        {
            get { return sendMsg; }
            set { sendMsg = value; }
        }

        public String RcvMsg
        {
            get { return rcvMsg; }
            set { rcvMsg = value; }
        }


        bool LogIn()
        {
            return true;
        }
        bool LogOff()
        {
            return false;
        }

        string chat()
        {
            // check if other client is online based on the return send data


            SendMsg = "tada";
            RcvMsg = "tada";

            return "data";
        }
    
    }
}
