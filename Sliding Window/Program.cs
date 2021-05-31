using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sliding_Window
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Program p = new Program();
            int [] arr = {1,4,2,10,23,3,1,0,20};
            int k = 4;
           // p.MaxSumSubArrayOfSizeK(arr,k);

            int[] myArr = {12,-1,-7, 8,-15,30,16,28};
            int size = 3;
            p.FirstNegativeNumberInWindowSizeOfK(myArr,size);
            Console.ReadLine();
        }

        public void MaxSumSubArrayOfSizeK(int [] arr, int k)
        {

            int i = 0; int j = 0; int sum = 0; int max_sum = 0;

            while (j < k)
            {
                sum = sum + arr[j];
                j++;
            }
            max_sum = sum;
            while (j < arr.Length)
            {

                sum = sum - arr[i];
                sum = sum + arr[j];
                if (sum > max_sum)
                {
                    max_sum = sum;
                }
                i++; j++;
            }
            Console.WriteLine("Max sum :  " + max_sum);
        }

        public void FirstNegativeNumberInWindowSizeOfK(int [] arr, int k)
        {
            int i = 0; int j = 0; List<int> NegativeNUmber = new List<int>();

            while (j < arr.Length)
            {
                if (arr[j] < 0)
                {
                    NegativeNUmber.Add(arr[j]);
                }
                if (j - i + 1 == k)
                {
                    if (NegativeNUmber.Count == 0)
                    {
                        Console.WriteLine(0);
                    }
                    else if (arr[i] == NegativeNUmber.First())
                    {
                        Console.WriteLine(NegativeNUmber.First());
                        NegativeNUmber.RemoveAt(0);
                    }
                    else
                    {
                        Console.WriteLine(NegativeNUmber.First());
                    }
                    i++;
                   
                }
                j++;
            
            }
        }
    }
}
