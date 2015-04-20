using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace customer
{
    class customer
    {
        private int custid = -1;

        public int Custid
        {
            set
            {
                //custid = custid + 10;
                custid = value+10;

            }
            get
            {
                return custid;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            customer cust = new customer();
            cust.Custid = 10;

            Console.WriteLine(cust.Custid);
            Console.ReadLine();
        }
    }
    class CarPart
    {
        public long PartNumber;
        public string PartName;
        public double UnitPrice;

        public CarPart Next;
    }

}
