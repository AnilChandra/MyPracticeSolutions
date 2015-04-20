using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP
{
    class DP
    {

        public int  DPLongestPlaindrome(char[] str, int[,] matrix)
        {
            //for (int i = 0; i < str.Length; i++)
            //{
            //    matrix[1, i] = 1;
            //}

            //for (int c = 2; c <= str.Length; c++)
            //{
            //    for (int i = 1; i <= str.Length - c + 1; i++)
            //    {
            //        if (str[i - 1] == str[i - 1 + c - 1] && c == 2)
            //        {
                      

            //            matrix[c, i] = 2;
            //        }
            //        else if (str[i - 1] == str[i + c - 2])
            //        {
            //           // T[c][i] = T[c - 2][i + 1] + 2;

            //            matrix[c, i] = matrix[c - 2, i + 1] + 2;
            //        }
            //        else
            //        {
            //           // T[c][i] = Math.max(T[c - 1][i + 1], T[c - 1][i]);

            //            matrix[c, i] = Math.Max(matrix[c-1,i+1], matrix[c-1,i]);
            //        }
            //    }
                
            //}

            //return matrix[str.Length, 1];

            for (int i = 0; i < str.Length; i++ )
            {
                matrix[i, i] = 1;
            }

         
            int A = 0;
            int B = 0;

            for (int k = 1; k < str.Length; k++)
            {
                for (A = 0; A < str.Length; A++)
                {
                    B = A + k;

                    if (B >= str.Length)
                        break;

                    if (str[A] == str[B])
                    {
                        matrix[A, B] = matrix[A + 1, B - 1] + 2;
                    }
                    else
                    {
                        matrix[A, B] = Math.Max(matrix[A, B - 1], matrix[A + 1, B]);
                    }

                }
            }
            return matrix[A-1, B-1];
            
        }

        public int LongIncrSubSeq(int [] A)
        {
           int [] T = new int[A.Length];

           for (int i = 0; i < T.Length; i++ )
           {
               T[i] = 1;
           }

           for (int i = 0; i < A.Length -1; i++ )
           {
               int  j = i + 1;
               i = 0;
               while(i < j)
               {
                   if (A[i] < A[j] && T[j] < T[i] +1)
                   {
                       T[j] = T[i] + 1;
                   }
                   i++;
               }
               i--;

           }

           int max = 0;
           for (int i = 0; i < T.Length; i++ )
           {
               if (T[i] > max)
                   max = T[i];

           }
           return max;

        }

        public void MaxIncSumSubSeq(int [] A)
        {
        
            int [] T = new int [A.Length];
            int [] Indexes = new int[A.Length];

            for (int i = 0; i < A.Length; i++ )
            {
                T[i] = A[i];
            }

            for (int i = 0; i < A.Length; i++)
            {
                Indexes[i] = i;
            }

            for (int i = 0; i < A.Length-1; i++ )
            {
                int j = i + 1;
                i = 0;
                while(i < j)
                {
                    if (A[j] > A[i]) 
                    {
                        if (T[j] < T[i] + A[j])
                        {
                            T[j] = T[i] + A[j];
                            Indexes[j] = i;
                        }
                    }
                    i++;
                }
                i--;
            }

            //check this code to get the series i.e. 4,6, 8 ??
            int max = 0; int MaxIndex = 0; int Fvalue =0;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] > max)
                {
                    max = T[i];
                    MaxIndex = i;
                    Fvalue = Indexes[i];
                }

            }


        }

        public void LongestCommonSubstr(char [] str1, char [] str2)
        {
            int  [ , ] T = new int[str2.Length +1, str1.Length +1];
            int max = 0;

            for (int i = 0; i < str2.Length - 1; i++ )
            {
                for (int j = 0; j < str1.Length - 1; j++ )
                {
                    if(str2[i] == str1[j])
                    {
                        T[i, j] = T[i-1, j-1] + 1;
                        if (max < T[i, j])
                        { 
                            max = T[i,j];
                        }

                    }
                }

            }
            Console.WriteLine(max);
            Console.ReadLine();
        
        }

        static void Main(string[] args)
        {
            DP dp = new DP();
            string s = "AGBDBA";
           // string s = "forgeeksskeegfor";
            char[] MyArray = s.ToCharArray();
            int [,] matrix = new int[s.Length,s.Length];
            //int length = dp.DPLongestPlaindrome(MyArray, matrix);
            //Console.WriteLine("Length of Longest Palindrome is :  " + length);
            //Console.Read();

            // Longest Icreasing Sub-Sequence
            // int[] A = {3,4,-1,0,6,2,3};
            //int[] A = { 2,5,1,8,3};
           // dp.LongIncrSubSeq(A);
            int[] A = { 4,6,1,3,8,4,6};
           // dp.MaxIncSumSubSeq(A);

            //Longest common substring in two strings
            String strA = "ABCDAF";
            String strB = "ZBCDF";

            char[] str1 = strA.ToCharArray();
            char[] str2 = strB.ToCharArray();

            dp.LongestCommonSubstr(str1, str2);
        }
    }
}
