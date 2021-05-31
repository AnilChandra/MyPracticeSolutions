using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksLIFO
{
    class Program
    {
        Node Head;
        //Node Tail;

        //public void Add(Node n) // Add at head LIFO
        //{
        //    if (Head == null)
        //    {
        //        Head = n;
        //    }
        //    else
        //    {
        //        n.Next = Head;
        //        Head = n;
        //    }

        //}

        public void Add(Node n) // Add at tail
        {
            if (Head == null)
            {
                Head = n;
            }
            else
            {
                Node current = Head;
                Node Previous = null;
                while (current != null)
                {
                    Previous = current;
                    current = current.Next;
                }
                current = n;
                Previous.Next = current;
                //Head.Next = current;
            }                     


        }
        public void Print()
        { 
          
            if(Head == null)
            { return; }
            Node current = Head;
            while(current!= null)
            {
                Console.Write(current.data +" ");
                current = current.Next;
            }
            Console.ReadLine();
        }

        public Boolean Pop(Node n)
        {
            Node Current = Head.Next;

            if(Head.data == '(' && n.data == ')')
            {

                Head = Current;
                Current = null;
                return true;
            }
            else if (Head.data == '[' && n.data == ']')
            {
                Head = Current;
                Current = null;
                return true;
            }
            return false;
        }
        public void EvaluateString(String expression)
        {

           String [] IndExpressions = expression.Split(' ');
            
            foreach(String word in IndExpressions )
            {
               if(word !="*" && word!="-" && word!= "+")
               {
                   Node n = new Node();
                   n.data = Convert.ToInt32(word);
                   Add(n);
               }
               else if (word =="*" || word =="-" || word =="+")
               {

                   wordpop(word);
               }
                
            }
            Console.WriteLine(Head.data);
            
                   
        }
        public void wordpop(string operation)
        {
            int opp1= OpperndPop();
            int opp2 = OpperndPop();

            if (operation == "*")
            {
                int result = opp1 * opp2;
                Node n = new Node();
                n.data = result;
                Add(n);
            }
            if (operation == "+")
            {
                int result = opp1 * opp2;
                Node n = new Node();
                n.data = result;
                Add(n);
            }
            if (operation == "-")
            {
                int result = opp1 * opp2;
                Node n = new Node();
                n.data = result;
                Add(n);
            }
            

        }
        public int OpperndPop()
        {
            Node Current = Head;
            Node temp = Head.Next;
            Head = temp;
            return Current.data;
            
        }
        public void ReverseLinkedList(Node n1)
        {

            Node Current, Prev = null, next = null;
            Current = n1;

            while (Current != null)
            {
                next = Current.Next;
                Current.Next = Prev;
                Prev = Current;
                Current = next;
                           
            }
            Head = Prev;
        }
               
        // Two sorted Linked Lists with a new Linked List with space complexity of O(1)
        public Node MergedLinkedLists(Node n1, Node n11)
        {

            Node Result = null;

            if (n1 == null)
                return n11;
            if (n11 == null)
                return n1;

            if (n1.data < n11.data)
            {
                Result = n1;
                Result.Next = MergedLinkedLists(n1.Next, n11);
            }
            else
            {
                Result = n11;
                Result.Next = MergedLinkedLists(n1, n11.Next);
            }
            return Result;
        
        }

        public void ReverseLL(Node x)
        {
            Node current= x;
            Node next = null;
            Node previous = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            Head = previous;
        }

        public void PrintReverse(Node p)
        {
            if (p == null)
                return;
            PrintReverse(p.Next);
            Console.Write(p.data + " ");

        }

        static void Main(string[] args)
        {

            Program p = new Program();
            //Node n1 = new Node();
            //n1.data = '[';
            //if (n1.data == '[' || n1.data == '(')
            //{
            //    p.Add(n1);
            //}
           

            //Node n2 = new Node();
            //n2.data = '(';

            //if (n2.data == '[' || n2.data == '(')
            //{
            //    p.Add(n2);
            //}

            //p.Print();

            //Node n3 = new Node();
            //n3.data = ')';
            //if (n3.data == ']' || n3.data == ')')
            //{
            //    p.Pop(n3);
            //}


            //Node n4 = new Node();
            //n4.data = '[';
            //if (n3.data == ']' || n3.data == ')')
            //{
            //    Boolean b= p.Pop(n4);
            //    if (!b)
            //    {
            //        Console.WriteLine("Busted");
            //        Console.ReadLine();
            //    }
            //}

            //Node n5 = new Node();
            //n5.data = 'E';

            Node n1 = new Node();
            n1.data = 1;

            Node n2 = new Node();
            n2.data = 20;

            Node n3 = new Node();
            n3.data = 22;

            Node n4 = new Node();
            n4.data = 4;

            Node n5 = new Node();
            n5.data = 5;


            p.Add(n1);
            p.Add(n2);
            p.Add(n3);
            p.Add(n4);
            p.Add(n5);

            p.Print();
            p.PrintReverse(n1);
            

          
            //String s = "23 * 3 + 5 * 4 - 9";
            //p.EvaluateString(s);

            // p.ReverseLinkedList(n1);
            // p.Print();

            //Program p2 = new Program();

            //Node n11 = new Node();
            //n11.data = 16;

            //Node n12 = new Node();
            //n12.data = 21;

            //p2.Add(n11);
            //p2.Add(n12);
            //p2.Print();
            Console.ReadLine();
            //p.MergedLinkedLists(n1, n11);



        }
    }
}
