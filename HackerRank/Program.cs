using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {

        public int[] ReverseString()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int arrLength = a.Length - 1;
            int start = 0;

            while (start <= arrLength)
            {
                int temp;
                temp = a[arrLength];
                a[arrLength] = a[start];
                a[start] = temp;
                arrLength--;
                start++;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(" " + a[i]);
            }
            return a;
        }

        public int HourglassSum(int[][] array)
        {
            int[][] arr = new int[][]
            {
                new int [] {-9,-9,-9,1,1,1},
                new int [] {0,-9,0,4,3,2},
                new int [] {-9,-9,-9,1,2,3},
                new int [] {0,0,8,6,6,0},
                new int [] {0,0,0,-2,0,0},
                new int [] {0,0,1,2,4,0}
            };

            int top = 0;
            int bottom = 2;
            int left = 0;
            int right = 2;
            int sum = 0;
            List<int> sumArray = new List<int>();

            while (top < 4 && bottom < 6)
            {
                for (int i = left; i <= right; i++)
                {
                    sum = sum + arr[top][i];
                }
                right++;
                for (int i = left; i < right; i++)
                {
                    sum = sum + arr[bottom][i];
                }
                left++;
                sum = sum + arr[bottom - 1][left];
                sumArray.Add(sum);
                sum = 0;
                if (left == 4 && right == 6)
                {
                    top++; bottom++;
                    left = 0; right = 2;
                }
            }
            //Console.WriteLine("Max is :" + sumArray.Max());
            //Console.ReadLine();

            return sumArray.Max();
        }
        public void LeftRotation()
        {
            int[] a = { 1,2,3,4,5,6};
            int n = a.Length;
            int d= 2;
            int reminder = d % n;
            Console.WriteLine(reminder);
            if (reminder > 0)
            {
                for (int i = 0; i < d; i++)
                {
                    int temp = a[0];
                    int initializer = 0;
                    while (initializer < n - 1)
                    {
                        a[initializer] = a[initializer + 1];
                        initializer++;
                    }
                    a[n - 1] = temp;
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadLine();
        }
        public void LeftRotation1()
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            int n = a.Length;
            int d = 2;
            int reminder = d % n;
            if (reminder > 0)
            {
                var temp = new int[n];
                for (int i = 0; i < n - reminder; i++)
                {
                    temp[i] = a[reminder + i];
                }

                for (int i = 0; i < reminder; i++)
                {
                    temp[n - reminder + i] = a[i];
                }

                a = temp;
            }
            Console.WriteLine(string.Join(" ", a));
            Console.ReadKey();
        }
        public int[] matchingStrings(string[] strings, string[] queries)
        {
            int[] res = new int [queries.Length];
            Dictionary<string, int> collection = new Dictionary<string, int>(); 

            for (int i =0; i < strings.Length; i++)
            {
                if (!collection.ContainsKey(strings[i]))
                    collection.Add(strings[i], 1);
                else
                    collection[strings[i]]++;

            }
            for (int i = 0; i < queries.Length; i++)
            {

                if (collection.TryGetValue(queries[i], out int value))
                {
                    //Console.WriteLine(value);
                    res[i] = value;
                }
                else
                {
                    res[i] = 0;
                }
            }
            
            //Console.ReadLine();
            //for(int i =0; i<res.Length; i++)
            //{
            //    Console.WriteLine("FOREACH VAR: {0}, {1}", res[i]);
            //}
            //Console.ReadLine();
            return res;

        }
        long arrayManipulation(int n, int[][] queries)
        {
            // int [,] arr = new int[queries.Length+1,n];

            //for(int i=0; i < arr.GetUpperBound(0);i++)
            //{
            //    for (int j = 0; j < arr.GetUpperBound(1); j++)
            //    {
            //        arr[i, j] = 0;
            //    }
            //}
            long[,] arr = new long[queries.Length + 1, n];
            int m = 1;
            long querySum = 0;
            long max = 0;
            int increment = 0;
            while (m <= queries.Length)
            {
                
                querySum = querySum + queries[m-1][2];
                for (int j = queries[m - 1][queries[m - 1].Length - 2]; j >= queries[m - 1][0]; j--)
                {

                    arr[m, j - 1] = arr[m - 1, j - 1] + querySum + arr[m, j - 1];
                    if (arr[m, j - 1] > max)
                        max = arr[m, j - 1];
                }

                for (int i = 0; i < queries[increment][0] - 1; i++)
                {
                    arr[m, i] = arr[m - 1, i] + arr[m, i];
                    if (arr[m, i] > max)
                        max = arr[m, i];
                }

                for (int j = queries[m - 1][1]; j < arr.GetLength(1); j++)
                {
                    arr[m, j] = arr[m - 1, j] + arr[m, j];
                    if (arr[m, j] > max)
                        max = arr[m, j];
                }
                increment++;
                querySum = 0; m++;
            }


            return max;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.ReverseString();
            int[][] array = new int[6][];
            // p.HourglassSum(array);
            //p.LeftRotation1();
            string[] strings = { "abcde", "sdaklfj", "asdjf", "na", "basdn", "sdaklfj", "asdjf", "na", "asdjf","", "na","", "basdn", "sdaklfj", "asdjf","" };
            string[] queries = { "abcde", "sdaklfj", "asdjf", "na", "basdn","" };

            int[] res = p.matchingStrings(strings, queries);

            //int[][] queries = new int[][]
            //{
            //    new int [] {1,5,3},
            //    new int [] {4,8,7},
            //    new int [] {6,9,1},

            //};


            //int[][] queries = new int[][]
            //{
            //    new int [] {1,2,100},
            //    new int [] {2,5,100},
            //    new int [] {3,4,100},

            //};

            //int[][] queries = new int[][]
            //{
            //    new int [] {778, 3330, 152792},
            //    new int [] {442, 1282, 529876},
            //    new int [] {1653, 3109, 21175},
            //    new int [] {3116, 3834, 105877},
            //    new int [] {146, 3595, 406523},
            //    new int [] {379, 561, 938920},
            //    new int [] {243, 1318, 865056},
            //    new int [] {1991, 3725, 342448},
            //    new int [] {1301, 3248, 554541},
            //    new int [] {2465, 3994, 288890},
            //    new int [] {1295, 2146, 630019},
            //    new int [] {2440, 2588, 931301},
            //    new int [] {425, 1492, 597877},
            //    new int [] {570, 3721, 173823},
            //    new int [] {1482, 2244, 9745548},
            //    new int [] {1165, 2799, 443148},
            //    new int [] {1141, 2573, 798873},
            //    new int [] {1373, 2442, 954472},

            //};

            //int[][] q = new int[3][];
            //int n = 5;
            //long result = p.arrayManipulation(n, queries);


        }
    }
}
