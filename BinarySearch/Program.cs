using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BinarySearch
{
    class Program
    {

        public int BSearch(int [] Myarray, int SearchString, int ArrayLength)
        {

            int Start = 0;
            int End = ArrayLength - 1;
            while(Start <= End)
            {
                int tada = ((7 - 1) / 8 + 1);
                int tada1= ((12 - 1) / 8 + 1);
                int tada2 = ((17 - 1) / 8 + 1);

                int middle = (Start + End) / 2;
                if(SearchString == Myarray[middle])
                {
                    return middle;
                }
                else if (SearchString < Myarray[middle])
                {
                    End = middle - 1;
                }
                else
                {
                    Start = middle + 1;
                }
            
            }
            
            
            return -1;
        }
        public int FindOccurence(int [] Myarray,int SearchString, int ArrayLength, bool FindLast)
        {

            int Start = 0;
            int End = ArrayLength - 1;
            int result = -1;
            while (Start <= End)
            {
                 int middle = (Start + End) / 2;
                if (SearchString == Myarray[middle])
                {
                    result = middle;
                    if (FindLast)
                    {
                        Start = middle + 1; // to find the last occurence of a number
                    }
                    else
                    {
                        End = middle - 1; // to find the first occurence of a number
                    }

                }
                else if (SearchString < Myarray[middle])
                {
                    End = middle - 1;
                }
                else
                {
                    Start = middle + 1;
                }

            }


            return result;
        
        }
        public int FindRotationCount(int [] Myarray, int ArrayLength)
        {
            int start = 0;
            int End = ArrayLength - 1;
            


            while(start <= End)
            {


                if (Myarray[start] <= Myarray[End])
                {
                    return start;
                }
                int middle = (start + End) / 2;
                int prev = (middle - 1) % ArrayLength;
                int next = (middle + 1) % ArrayLength;

                if (Myarray[middle] <= Myarray[prev] && Myarray[middle] <= Myarray[next])
                {
                    return middle;
                }
                else if(Myarray[middle] <= Myarray[End])
                {
                    End = middle -1;
                }
                else if(Myarray[middle] >= Myarray[End])
                {
                    start = middle + 1;
                }
                
           
            }

            
            return -1;
        }
        static void Main(string[] args)
        {

            Program p = new Program();
            int[] Myarray = {11,12,12,12,12,15,18,19,20,21,22};
            int SearchString = 13;

            // 0. Search a string in sorted array
            int index = p.BSearch(Myarray, SearchString, Myarray.Length);
            Console.WriteLine(index);
            Console.ReadLine();


           // 1. Occurences of number in an array
            //int SearchString = 12;
            //Boolean FindLast = true;
            //int LastIndex = p.FindOccurence(Myarray, SearchString, Myarray.Length, FindLast);

            //FindLast = false;
            //int FirstIndex = p.FindOccurence(Myarray, SearchString, Myarray.Length, FindLast);

            //int NumberOfOccerances = (LastIndex - FirstIndex) + 1; // occurences of a number in sorted array with dupilcates using Bindary search
            //Console.WriteLine("Number of Occurences : " + NumberOfOccerances);
            //Console.ReadLine();

            // 2. Hom many times is a sorted array rotated
            //int NoOfRotations = p.FindRotationCount(Myarray, Myarray.Length);
            //Console.WriteLine("Number of rotations are " + NoOfRotations);
            //Console.ReadLine();


        }
    }
}
