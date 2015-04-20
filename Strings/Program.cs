using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
namespace Strings
{
    class Program
    {

        int [] Fib = new int[50];
       
        

        static void Main(string[] args)
        {

            #region
            /*

            char[] name = new char[] { 's', 'w', 'e', 't','h' };
            int mylength = name.Length -1;
            char  [] temp = new char[1];
            for (int counter = 0; counter < (name.Length / 2)  ; counter++)
            {
                //Console.WriteLine("charArray[" + counter + "] = " +
                //  charArray[counter]);
                
                temp[0] = name[counter];
                name[counter] = name[mylength];
                name[mylength] = temp[0];
                mylength--;
                
            }
            Console.WriteLine(name);
           
            Console.ReadLine(); */
            
            /*
            String s1 = "my's name is anil";
            //Regex delim= new Regex(" ");

            StringBuilder sbuilder = new StringBuilder();
            String[] splitstring = Regex.Split(s1," ");
            int mylength = splitstring.Length - 1;
            string temp = "";

            for (int i = 0; i < (splitstring.Length/2); i++)
            {
                temp = splitstring[i];
                splitstring[i] = splitstring[mylength];
                splitstring[mylength] = temp;
                mylength--;
                
                //sbuilder.Append(splitstring[i]);
            }
           // Console.WriteLine(sbuilder);
            StringBuilder mystring = new StringBuilder();
            for (int i = 0; i < splitstring.Length; i++)
            {
               
                sbuilder.AppendFormat("{0} {1}",splitstring[i],' ');
                char[] array = splitstring[i].ToCharArray();
                int len = array.Length - 1;
                for (int j = 0; j < (array.Length/2); j++)
                {
                    char tmp = array[j];
                    array[j] = array[len];
                    array[len] = tmp;
                    len--;
                   

                }
              
                string s = new string(array);
                mystring.AppendFormat("{0} {1}", s, ' ');
                
            }
            Console.WriteLine(mystring);
            Console.ReadLine(); 
            */
            // plaindrome
            /*
            string mystring = "sums are not set as a test on erasmus";
            //string[] splitstring = Regex.Split(mystring," "); 
            char[] myarray = mystring.ToCharArray();
            //char[] myarray = splitstring.ToArray;
            //Never odd or even
            int len = myarray.Length - 1;
            for(int j=0;j<= (myarray.Length/2);j++)
            {

                if (myarray[j] == ' ') j++;
                if(myarray[len]==' ') len--;
                   
                
                
                    if (myarray[j] == myarray[len])
                    {
                        len--;
                        //if (len == myarray.Length / 2)
                        //{
                        //    Console.WriteLine("String is a palindrome: {0}", mystring);
                        //}
                        if (j >= len)
                        {
                            Console.WriteLine("String is a palindrome: {0}", mystring);
                        }
                    }

                    else
                    {
                        Console.WriteLine("String is not palindrome: {0}", mystring);
                        break;
                    }
                   
                
            }
            Console.ReadLine(); */
           /*
            string str = string.Empty;
            Console.WriteLine("Enter a String");
            string s = Console.ReadLine();
            int i = s.Length;

            //we can get the Length of string by using Length Property
            for (int j = i - 1; j >= 0; j--)
            {
                str = str + s[j];
            }
            Console.WriteLine(str);
            if (str == s)
            {
                Console.WriteLine(s + " is palindrome");
            }
            else
            {
                Console.WriteLine(s + " is not a palindeome");
            }

            Console.ReadLine(); */
             
            /*
            string myString = "never                        o d   .            d or  even    ";

            List<char> invalidChars = new List<char>() { ',', '.', ' ', '!', '@' };
            char[] myArr = myString.ToCharArray();

            int i = 0;
            int j = myArr.Length - 1;
            while (i <= j)
            {
                while (invalidChars.Contains(myArr[i])) { i++; };
                while (invalidChars.Contains(myArr[j])) { j--; };
              
              //if (myArr[i] == ' ') i++;
               // if (myArr[j] == ' ') j--;
                
                if (myArr[i] != myArr[j]) break;

                i++;
                j--;

            }

            if (i >= j) Console.WriteLine("This is a palindrome");
            else Console.WriteLine("This is not a palindrome");

            //Console.WriteLine(str); 
            Console.Read(); */
            #endregion


           

            //Console.WriteLine("Pls eneter a number: ");

            //int num;

            //num = Convert.ToInt32(Console.ReadLine());
           
            Program p = new Program();
            //Console.WriteLine(p.RecFib(num));
            //int[] MyArray = {7,2,1,6,8,5,3,4};

            ////p.MergeSort(MyArray);
            //p.QuickSort(MyArray, 0, 7 );
            //p.findprime(num);
           // p.fibnocci(num);

            //Console.WriteLine(p.fibnocci(num));
            //Console.ReadLine();
            

            // strip white places in a string


            Console.WriteLine("Pls enter a string : ");
            string mystring = Convert.ToString(Console.ReadLine());
           // Program p = new Program();
            //p.

            //for (int i = 0; i < MyArray.Length; i++)

            //{
            //    Console.Write(MyArray[i] + " ,");
            
            //}
                // Console.WriteLine(p.factR(num));
               // Console.ReadLine();
           // CheckCyclicArray(mystring);
          // int value = p.CheckCyclicArray(mystring);

           // p.annagram();

           // p.removeshitespace(mystring);
            p.removeduplicate(mystring);
           // p.RemoveDuplicateCharsFast(mystring);
            //string value1= RemoveDuplicateCharsFast(mystring);
            //Console.WriteLine(value1);
            //Console.ReadLine();
           // p.findFirstUniquechar(mystring);
            //char myvalue = p.GetFirstNonRepeatedChar(mystring);
            //Console.WriteLine(myvalue);
            //Console.ReadLine();
            //p.test(mystring);
             // p.inplacereverse(mystring);
           // p.bubblesort();
           // p.insertionsort();

            //int count = 0;
            //int total = Recursive(8, ref count);

           

            //Console.ReadLine();
           // p.findcommonelements();
            //p.pythagorean();

            




            //List<int> newList = quickSort(tempData, 0, tempData.Count - 1);
            //for (int b = 0; b < newList.Count; b++)
            //{
            //    Console.WriteLine(newList[b]);
            //}
            //List<int> newList = quicksort(tempData, 0, tempData.Count - 1);
            //for (int b = 0; b < newList.Count; b++)
            //{
            //    Console.WriteLine(newList[b]);
            //}
            //Console.ReadLine();

            //p.uniquecharstring(mystring);
            //p.numberoftows();

        }


        public int MergeSort(int [] MyArray)
        {

            int length = MyArray.Length;

            if (length < 2)
            {
                return length;
            }

            int middle = length / 2;

            int [] Left = new int[middle];
            int [] Right = new int[length-middle];

                       
            for (int i = 0; i < middle; i++)
            {
                Left[i] = MyArray[i];
            }   
            
            for (int j = middle; j < length; j++)
            {
                Right[j-middle] = MyArray[j];
                    
               
            }
            MergeSort(Left);
            MergeSort(Right);

            MyMerge(Left,Right,MyArray);

            return 0;
            
        }
        public int MyMerge(int [] Left, int[] Right, int[] MyArray)
        {
            int i = 0, j=0, k=0;
            while (i < Left.Length && j < Right.Length )
            {
                if (Left[i] <= Right[j])
                {
                    MyArray[k] = Left[i];
                    i++;
                    
                }
                else
                {
                    MyArray[k] = Right[j];
                    j++;
                    
                }
                k++;
            }
            while( i < Left.Length)
            {
                
                    MyArray[k] = Left[i];
                    k++;
                    i++;

            }
            while(j < Right.Length)
            {
                    MyArray[k] = Right[j];
                    j++;
                    k++;       
            }
           
            return 0;
        }


        public void QuickSort(int [] MyArray, int Start, int End)
        {

            if (Start < End)
            {
                int Index = Partition(MyArray, Start, End);
                QuickSort(MyArray, Start, Index - 1);
                QuickSort(MyArray, Index + 1, End);
            }

            
        }
        public int Partition(int [] MyArray, int Start, int End)
        {
            int Index = Start;
            int Pivot = MyArray[End];
            int temp = 0;

            for (int i = Start; i < End; i++)
            { 
                if(MyArray[i] <= Pivot)
                {
                    //Swap(MyArray[i], MyArray[Index]);

                    temp = MyArray[i];
                    MyArray[i] = MyArray[Index];
                    MyArray[Index] = temp;

                    Index = Index + 1;
                }
            }
            //swap(MyArray[Pivot], MyArray[Index]);
            temp = MyArray[Index];
            MyArray[Index] = MyArray[End];
            MyArray[End] = temp;
            


            return Index;
        }

        public int NonRecFibb(int length)
        {
            //int length = 5;

            if (length == 0)
            {
                Console.WriteLine("OOops!! no fib series");
                return 1;
            }

            int a = 0, b = 1, result = 0;
            

            for (int i = 0; i < length; i++ )
            {

                result = a + b;
                Console.WriteLine(result);
                b = a;
                a = result;
               
                
            }
            //Console.WriteLine("Nth Fib number is : {0} ",b);
            return b;

            //Console.ReadLine();
            //return 0;
        
        }

        public int RecFib(int length)
        {
            if (length == 0) return 0;
            if (length == 1) return 1;
            
            if (Fib[length] != 0)
            {
                return Fib[length];
            }

            return Fib[length] = RecFib(length - 1) + RecFib(length -2);
            
        }

        public int fibnocci(int num)
        {


            if (num == 0)
            {
                return 0;
            }

            if (num == 1)
            {
                return 1;
            }

           return fibnocci(num - 1) + fibnocci(num -2);
           
        }

        public void findprime(int num)
        {
            int i;
            for (i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    Console.WriteLine("{0} is not a prime number",num);
                    break;
                    
                }

            }
            if(i==num)
            {
                Console.WriteLine("{0} is a prime number", num);
               
            }
        }
        public void removeshitespace( string mystring)
        {
           
            string str = "";
          

            for (int j = 0; j <= mystring.Length - 1; j++)
            {
                if(mystring[j]!= ' ')
                str = str + mystring[j];
            }

                Console.WriteLine(str);
            Console.ReadLine();
        }
        public void removeduplicate(string mystring)
        {
            
         
            int i =0;

            int length = mystring.Length;

           
            char [] result = new char[length];
            int resultlength = 0;

            foreach (char value in mystring)
            { 

                  bool exists = false;  
                  for( i=0 ; i < resultlength ; i++)
                  {
              
                    if(value== result[i])
                    {
                        exists = true;
                        break;
                    }
                  }
                
                if (!exists)
                { 
                    result[resultlength] = value;
                    resultlength++;
            
                } 
           }
          

                

            
                
        }
        /*static string RemoveDuplicateCharsFast(string key)
        {
            // --- Removes duplicate chars using char arrays.
            int keyLength = key.Length;

            // Store encountered letters in this array.
            char[] table = new char[keyLength];
            int tableLength = 0;

            // Store the result in this array.
            char[] result = new char[keyLength];
            int resultLength = 0;

            // Loop through all characters
            foreach (char value in key)
            {
                // Scan the table to see if the letter is in it.
                bool exists = false;
                for (int i = 0; i < tableLength; i++)
                {
                    if (value == table[i])
                    {
                        exists = true;
                        break;
                    }
                }
                // If the letter is new, add to the table and the result.
                if (!exists)
                {
                    table[tableLength] = value;
                    tableLength++;

                    result[resultLength] = value;
                    resultLength++;
                }
            }
            // Return the string at this range.
            return new string(result, 0, resultLength);
        } */
        public void findFirstUniquechar(String mystring)
        {

            int index = 0;
            char [] myarray = mystring.ToCharArray();
            int arraylength = myarray.Length - 1;
            int i;
            foreach (char mychar in myarray)
            {
                int count = 0;

                for (i = 0; i <= arraylength; i++)
                {
                    //if (i == index && index!=arraylength)
                    //{
                    //    i++;
                    //}
                    //if (myarray[i] == mychar && index != arraylength)
                    //{
                    //    break;

                    //}

                    if (i != index)
                    {

                        if (myarray[i] == mychar)
                        {
                            break;
                        }
                        else
                        {
                            count = count + 1;
                            if (count == arraylength - 1)
                            {
                                Console.WriteLine("{0} is the first unique char", mychar);
                                Console.ReadLine();
                            }
                        }
                    }
                    

                }
                index++;
                //if (i > arraylength)
                //{
                //    Console.WriteLine("{0} is the first unique char", mychar);
                //    Console.ReadLine();
                //    break;
                //}

            }
            return;
        }
        private char GetFirstNonRepeatedChar(string value)

        {
            // declare a character array.
            char[] cArr = null;
            try
            {
                // load the string to char array.
                cArr = value.ToCharArray();


                for (int i = 0; i < cArr.Length; i++)
                {
                    // count to track all comparison has over              
                    int count = 0;
                    for (int j = 0; j < cArr.Length; j++)
                    {
                        // avoids to comparison for same character
                        if (i != j)
                        {
                            // if repeated then come out of the inner loop
                            if (cArr[i] == cArr[j])
                            {
                                break;
                            }
                            else
                            {
                                // increament the count for each non repeatable comparison
                                count = count + 1;
                                // if the count reaches the char array length - 1
                                // and you are inside the for loop then the current value
                                // is the first non repeated character.
                                if (count == cArr.Length - 1)
                                {
                                    return cArr[i];
                                }
                            }
                        }
                    }
                }
                return '0'; // if no non repeated char is fount
            }
            catch (Exception)
            {

                throw;
            }            

        }
        public void inplacereverse(string mystring)
        {
           
            //String[] splitstring = Regex.Split(mystring, " ");
           // StringBuilder sbuilder = new StringBuilder();

            /*
            foreach (string s in splitstring)
            {
                char[] myarray = s.ToCharArray();
                int j = myarray.Length - 1;
                int i = 0;
                while(i<j)
                {
                    char temp = myarray[i];
                    myarray[i] = myarray[j];
                    myarray[j] = temp;
                    i++;
                    j--;
                }
                string st = new string(myarray);
               sbuilder.AppendFormat("{0} ",st);
                              
            }
            Console.WriteLine(sbuilder.ToString());
            Console.ReadLine(); */
            
            // Reverse the string as is
            char[] myarray = mystring.ToCharArray();
            int j = myarray.Length - 1;
            int i = 0;
            while (i < j)
            {
                char temp = myarray[i];
                myarray[i] = myarray[j];
                myarray[j] = temp;
                i++;
                j--;
            }
            string st = new string(myarray);
                       
            Console.WriteLine(st);
            Console.ReadLine();

        }
        public void test(string inputstring)
        { 
            

            
        }

        public int CheckCyclicArray(String mystring)
        {



            String Cyclic = "bdca";
            char [] CyclicArray = Cyclic.ToCharArray();
            int CyclicLength = CyclicArray.Length - 1;

            char[] myarray = mystring.ToCharArray();
            int MyArrLength = myarray.Length -1;

            int count = 0;

            int i =0;
            for (int j = 0; j <= CyclicLength; j++)
            {
                
                    while (CyclicArray[j] != myarray[i])
                   {
                       i++;
                       count++;    
                   }
                   if( count >1 && j >=1)
                   {
                       return 1; 
                       //break;
                   }
                   if(i==MyArrLength)
                   {
                     i=0;
                   }
                   count = 0;

            }
            return 0;
           


        }
        public void bubblesort()
        {

            char[] mychar = new char[] { };
            int[] myarray = new int[] { 12, 8, 45, 9, 1};
            int temp;
            for(int i=0 ; i < myarray.Length - 1;i++)
            {
                for (int j = 0; j < myarray.Length - 1; j++ )
                {
                    if(myarray[j] > myarray[j+1])
                    {
                        temp = myarray[j];
                        myarray[j] = myarray[j+1];
                        myarray[j + 1] = temp;
                    }
                }
            }
            foreach (int i in myarray)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
        public void insertionsort()
        {

            int[] myarray = new int[] { 24,13,9,64,7,23,34,32};
            int length=0;
            int j = 0;

            for (int i = 1; i <= myarray.Length-1 ; i++ )
            {
                //for (int j = 0; j <= length && j < myarray.Length - 1; j++)
                //{

                //    //if (j < myarray.Length - 1)
                //    //{
                //        if (myarray[j] > myarray[j + 1])
                //        {
                //            int temp;
                //            temp = myarray[j];
                //            myarray[j] = myarray[j + 1];
                //            myarray[j + 1] = temp;
                //        }
                //    //}
                //} 
                //length++;
                j = i;
                while(j > 0)
                {
                    if (myarray[j] > myarray[j - 1])
                    {
                        int temp;
                        temp = myarray[j-1];
                        myarray[j-1] = myarray[j];
                        myarray[j] = temp;
                    }
                    j = j - 1;
                }
                
            }
            foreach (int i in myarray)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
        static int Recursive(int value, ref int count)
        {
            count++;
            if (value >= 10)
            {
                // throw new Exception("End");
                return value;
            }
            return Recursive(value + 1, ref count);
        }

        public int factR(int n)
        {
            int result;

            if (n == 1)
            {
                return 1;
            }
            result = factR(n - 1) * n;
            return result;
        }

         static List<string> jobs = new List<string>(16);
         static int nextJobPos = 0;

        public static void AddJob(string jobName)
        {
            jobs.Add(jobName);
        }

        public static string GetNextJob()
        {
            if (nextJobPos > jobs.Count - 1)
                return "NO JOBS IN BUFFER";
            else
            {
                string jobName = jobs[nextJobPos];
                nextJobPos++;
                return jobName;
            }
        }
        public void findcommonelements()
        { 
            int [] array1 = new int[] {7,9,34,100};
            int[] array2 = new int[] {8,10,19,34,89};

            Hashtable ht = new Hashtable();
            ht.Add(1,7);


            for (int i = 0; i < array1.Length; i++ )
            {
                for (int j = 0; j < array2.Length; j++)
                {

                    if (array1[i] == array2[j])
                    {
                        Console.WriteLine( "The matching elements are {0} {1}",array2[j],array1[i]);

                    }
                }
             
            }
            Console.ReadLine();

           
                    
        }
        public void pythagorean()
        {

            int[] myarray = new int[] {3,4,5,7,12,13,80 };
            int i, j = 0;
            StringBuilder mystring = new StringBuilder();


            for (i = 0; i < myarray.Length -1; i++ )
            {

                for (j = i + 1; j < myarray.Length -1; j++)
                {
                    if (myarray[j + 1] > myarray[i] + myarray[j])
                    {
                        break;
                    }
                    
                    else
                    {
                        if(((myarray[i]*myarray[i])+(myarray[j]*myarray[j]))== (myarray[j+1] * myarray[j+1]))
                        {
                            mystring.Append( myarray[i]);
                            mystring.Append( myarray[j] );
                            mystring.Append( myarray[j+1] );
                            mystring.AppendLine();
                        } 
                    }
                
                }
            }
            Console.WriteLine(mystring);
            Console.ReadLine();

        }
        private static List<int> quicksort(List<int> myint, int left, int right)
        {

            //int[] myint = new int[] {24,5,3,35,14,23,19,43,2};

            int i = left;
            int j = right;
            int pivot = ((i + j) / 2);
            int temp=0;
            
            while(i<j)
            {
               
                    while (myint[i] < myint[pivot])
                    {
                        i++;
                    }
                    while (myint[j] > myint[pivot])
                    {
                        j--;
                    }
                    //temp = myint[j];
                    //myint[j] = myint[i];
                    //myint[i] = temp;
                    temp = myint[i];
                    myint[i++] = myint[j];
                    myint[j--] = temp;
                
            }
            if (i < right)
            {
                //quickSort(myint, i, right);
                quicksort(myint, i, right);
            }
            if (left < j)
            {
                //quickSort(myint, left, j);
                quicksort(myint, left, j);
            }
           

            //for (int q = 0; q < myint.Length; q++)
            //{
            //    Console.WriteLine(myint[q]);
            //}

            return myint;
        }
        /*private static List<int> QuickSort(List<int> a, int left, int right)
        {

            int i = left;
            int j = right;
            double pivotValue = ((left + right) / 2);
            int x = a[Convert.ToInt32(pivotValue)];
            int w = 0;
            while (i <= j)
            {
                while (a[i] < x)
                {
                    i++;
                }
                while (a[j] > x)
                {
                    j--;
                }
                //if (i <= j)
                //{
                w = a[i];
                a[i++] = a[j];
                a[j--] = w;
                //}
                
            }
            if (left < j)
            {
                QuickSort(a, left, j);
            }
            if (i < right)
            {
                QuickSort(a, i, right);
            }
            return a;
        }*/

        public void uniquecharstring(string mystring)
        {

            //string mystring = new string();
            //char[] mychar = mystring.ToCharArray();

            int i, j = 0;

            for (i = 0; i < mystring.Length - 1; i++)
            {
                for (j = 0; j < mystring.Length - 1; j++)
                {
                    //if (mychar[i] != mychar[j])
                    if(mystring[i]!= mystring[j])
                        break;
                }
            
            }
            if (i == j)
            {
                Console.WriteLine(mystring + " is a unique character string");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(mystring + " is NOT a unique character string");
                Console.ReadLine();
            }
        }

        public void numberoftows()
        {

            //int  myarray[] = new Array[1,2];

            int[] myarray = new int[] { 2,120,122,1222,2202 };
            int counter = 0;

            for (int i = 0; i < myarray.Length; i++ )
            {
                int number = myarray[i];

                if (number == 2)
                {
                    counter++;
                   
                }
                while(number/10 != 0)
                {
                   
                    int reminder = number % 10;
                    
                    if (reminder == 2)
                    {
                        counter++;
                    
                    }
                    int qoffcient = number / 10;
                    if (qoffcient == 2)
                    {
                        counter++;
                    }

                    number = qoffcient;
                }
            }

            //n = 2 / 10;

            Console.WriteLine(counter);
            Console.ReadLine();
        }
        public void annagram()
        { 
            string provided = "debit card";
            List<int> Poccurences = new List<int>();
            Poccurences = CharacterOccurences(provided);
            Poccurences.Sort();

            string given = "bad credit";
            List<int> Goccurences = new List<int>();
            Goccurences = CharacterOccurences(given);
            Goccurences.Sort();

            bool flag = true;

            if(Poccurences.Count == Goccurences.Count)
            {
               
                for (int i = 0; i < Poccurences.Count; i++ )
                {
                    if (Poccurences[i] == Goccurences[i])
                    {

                    }
                    else
                    {
                        flag = false;
                        break;
                    }

                }
                if (flag) { Console.WriteLine("Given String is Anagram"); }
                else
                { Console.WriteLine("Given String is NOT an Anagram"); }
                
                
            }

            Console.ReadLine();
         

        }

        List<int> CharacterOccurences(string provided)
        {
            
            char[] MyProvided = provided.ToCharArray();
            List<int> mylist = new List<int>();
            int counter = 1;
            int flag = 0;
            for (int i = 0; i < MyProvided.Length; i++) // iterate through the legth of the array with pointer set to zero
            {
                // iterate through the legth of the array with pointer set to zero
                // this is to check if there is a previos occurence of a character
                
                for (int j = 0; j < MyProvided.Length; j++) 
                {

                    //check if the characters are equal and  it is not the same occurence i.e. pointer1 and pointer2 are not pointing the same character
                    if (MyProvided[i] == MyProvided[j] && i != j)
                    {
                       //check that character occurs after pointer1 
                        if (j > i)
                        {
                            counter++;
                        }
                        // character is already counted during the preious iteration and no need to count any further
                        else
                        {
                            flag = 1;
                            break;
                        }
                    }
                }

                if (counter > 1)
                {
                    mylist.Add(counter);
                    counter = 1;
                }
                else
                {
                    //add to list only if the character is not counted before
                    if (flag != 1)
                        mylist.Add(counter);
                }
                flag = 0;

            }
            return mylist;
        }
    }
}
