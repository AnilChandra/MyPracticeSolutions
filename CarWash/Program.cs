using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash
{
    class Program
    {
        Car Head;
        static void Main(string[] args)
        {

           // Initializing new car new car
            Car c = new Car();
            c.DeepWash = 4;
            c.WaterWash = 0;
            Program p = new Program();
            p.CarProcessing(c);
        

            Car c1 = new Car();

            c1.DeepWash = 5;
            c1.WaterWash = 6;
            p.CarProcessing(c1);

        }
        public void CarProcessing(Car C)
        {
            String CarType = "PriorityCar";
            if (C.DeepWash > 3)
            {
                if (C.WaterWash + C.DeepWash > 10)
                {
                    C.FreeWash = true;
                }

                C = new Car(CarType);

            }

        }
        // Have Linked List in Increasing Order Add o(n), PeekMin o(1), RemoveMin o(1)
        public void AddToPriority(Car n)
        {
            if (Head == null)
            {
                Head = n;
            }
            else
            {
                Car Current = Head;
                Car Previous = null;

                while(Current != null)
                {
                    Previous = Current;
                    Current = Current.Next;
                }
                Current = n;
                Previous.Next = Current;
            
            }
        
        }

        
    }

    public class Wash
    {
        private int waterWash;

        private int deepWash;

        private bool freeWash;

        public int WaterWash
        {
          get { return waterWash; }
          set {waterWash = value; }
        }

        public int DeepWash
        {
            get { return deepWash;}
            set {deepWash = value;}
        }

        public bool FreeWash
        {
            get { return freeWash; }
            set { freeWash = value; }
        
        }

    }

    public class Car : Wash
    {
        public Car()
        { 
        
        }

        public Car(string carType) : this ()
        {
            this.CarType = carType;
         
        }

        private string carType;

        public string CarType
        {
            get { return carType; }
            set { carType = value; }
        }

        public Car Next;
 
    }

}
