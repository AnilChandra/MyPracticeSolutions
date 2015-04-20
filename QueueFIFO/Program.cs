using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueFIFO
{
    class Program
    {
        int start = -1;
        int tail = -1;

        public bool IsEmpty()
        {
            if (start == -1 && tail == -1)
                return true;
            else
                return false;
        }
        
        public void Enqueue( int [] Myarray, int data)
        {


            if (start == -1 && tail == -1)
            {
                start = -1 + 1;
                tail = -1 + 1;
                Myarray[start] = data;
                Myarray[tail] = data;
                return;
                
               
            }
            // check if rear == front
            
            bool check = IsFull(Myarray);

            if (!check)
            {
                return;
            
            }

            else if(start != ((tail +1) % 4))
            {
                tail = (tail + 1) % 4; 
                Myarray[tail] = data;

            }

            //else if (tail == start)
            //{
            //    return;
            //}
        }

        public bool IsFull(int [] MyArray)
        {

            if (tail == MyArray.Length - 1)
                return false;
            return true;
        }

        public void DeQueue(int [] Myarray)
        { 
            if(start != -1 && tail != -1)
            {
                Console.WriteLine(Myarray[start]);
                start = (start + 1) % 4;
            }
            else if(start == tail)
            {
                return ;
                //start = tail = -1;
            }

        }
        static void Main(string[] args)
        {

            int [] Myarray = new int [4];
            Program p = new Program();
            p.Enqueue( Myarray, 10);
            p.Enqueue(Myarray, 2);
            p.Enqueue(Myarray, 14);
            p.Enqueue(Myarray, 11);
            p.DeQueue(Myarray);
            p.DeQueue(Myarray);
            p.Enqueue(Myarray, 15);
             
        }
    }
}
