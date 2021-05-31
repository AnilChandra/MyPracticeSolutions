using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Practice
{
    class Program
    {
        BsNode root;

        public void Add(BsNode n)
        {
            if (root == null)
            {
                root = n;
            }
            else
            {
                BtInsert(n, root);
            }
        }

        public void BtInsert(BsNode NewNode, BsNode root)
        {

            BsNode currentPtr = root;
            //BSTNode currentPtrPtr = currentPtr;
            int cData = currentPtr.GetData();
            int nData = NewNode.GetData();
            if (cData >= nData)
            {
                if (currentPtr.GetLeft() == null)
                {
                    currentPtr.SetLeft(NewNode);
                    return;
                }
                else
                {
                    currentPtr = currentPtr.GetLeft();
                    BtInsert(NewNode, currentPtr);
                }
            }
            else
            {
                if (currentPtr.GetRight() == null)
                {
                    currentPtr.SetRight(NewNode);
                    return;
                }
                else
                {
                    currentPtr = currentPtr.GetRight();
                    BtInsert(NewNode, currentPtr);
                }

            }

        }

        public void OddOccurenceOfNumberInArray(int[] arr)
        {

            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                result = result ^ arr[i];
            }
            Console.WriteLine("Odd occurence is :" + result);
            Console.ReadLine();
        }

        public void RainWaterTrapping(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            int rightMax = 0; int leftMax = 0; int ans = 0;
            while (start <= end)
            {
                if (arr[start] < arr[end])
                {
                    if (arr[start] > leftMax)
                    {
                        leftMax = arr[start];
                    }
                    else
                    {
                        ans = ans + leftMax - arr[start];
                    }
                    start++;
                }
                else
                {
                    if (arr[end] > rightMax)
                    {
                        rightMax = arr[end];
                    }
                    else
                    {
                        ans = ans + rightMax - arr[end];
                    }
                    end--;
                }
            }
            Console.WriteLine("Total rain water trapped : " + ans);
            Console.ReadLine();
        }

        public void InOrder(BsNode root)
        {
            if (root == null)
                return;

            InOrder(root.GetLeft());
            Console.WriteLine(root.GetData());
            InOrder(root.GetRight());
        }

        public void IterrativeInOrderTraversal(BsNode root)
        {
            BsNode current = root;
            Stack<BsNode> collection = new Stack<BsNode>();

            while (true)
            {

                while (current != null)
                {
                    collection.Push(current);
                    current = current.GetLeft();
                }
                if (collection.Count == 0)
                    break;

                BsNode pop = collection.Pop();
                Console.Write(pop.GetData() + ", ");
                current = pop.GetRight();


            }
        }

        public void FirstNonRepeatingCharacter(string s)
        {
            int[] index = new int[256];

            for (int i = 0; i < 256; i++)
            {
                index[i] = -1;
            }
            char[] cIndex = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(cIndex[i]);
                if (index[cIndex[i]] == -1)
                {
                    index[cIndex[i]] = i;
                }
                else
                {
                    index[cIndex[i]] = -2;
                }

            }
            int min = int.MaxValue;
            for (int i = 0; i < index.Length; i++)
            {
                if (index[i] > 0)
                {
                    if (index[i] < min)
                    {
                        min = index[i];
                    }
                }
            }
            Console.WriteLine("First non-repeating character is : " + min);
            Console.ReadLine();
        }

        public void MajorityElementInArray(int[] array)
        {

            Dictionary<int, int> collection = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (collection.ContainsKey(array[i]))
                {
                    collection[array[i]]++;
                }
                else
                {
                    collection.Add(array[i], 1);
                }
            }
            int formula = (array.Length / 2);
            foreach (var pair in collection)
            {
                Console.WriteLine("Key : " + pair.Key + " Value : " + pair.Value);
                if (pair.Value > formula)
                {
                    Console.WriteLine("The Majority element is : " + pair.Key);
                }
            }
        }

        public int RotationCount(int[] arr, int n)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                int mid = (start + end / 2);
                int prev = (mid + n) % n;
                int next = (mid + 1) % n;

                if (arr[start] <= arr[end]) // non-rotated array
                {
                    return start;
                }
                // found the element
                if (arr[mid] <= arr[prev] && arr[mid] <= arr[next])
                {
                    return mid;
                }
                // go left
                else if (arr[mid] <= arr[end])
                {
                    end = mid - 1;
                }
                // go right
                else if (arr[mid] >= arr[start])
                {
                    start = mid + 1;

                }
            }
            return -1;
        }

        public int PeakElementInArray(int[] arr, int n)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                int mid = (start + end / 2);
                int prev = (mid + n) % n;
                int next = (mid + 1) % n;

                if (arr[mid] > arr[prev] && arr[mid] > arr[next])
                {
                    return arr[mid];
                }
                if (arr[prev] >= arr[mid])
                {
                    end = mid - 1;
                }
                else if (arr[next] >= arr[mid])
                {
                    start = mid + 1;
                }
            }
            return -1;

        }

        public int CircularArraySearch(int[] arr, int n, int x)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start < end)
            {
                int mid = (start + end / 2);
                if (x == arr[mid])
                { return mid; }

                if (arr[mid] < arr[end]) // right half is sorted
                {

                    if (x > arr[mid] && x < arr[end])
                    {
                        start = mid + 1; // search is the right sorted half
                    }
                    else
                    {
                        end = mid - 1; // search left
                    }

                }
                else if (arr[start] < arr[mid]) // left half is sorted
                {

                    if (arr[start] < x && x < arr[mid]) // search in left sorted half
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1; // go searching right
                    }
                }

            }
            return -1;
        }

        //Random Elements Based on Probability
        public void RadomNumberWithWeights()
        {
            List<KeyValuePair<string, double>> elements = new List<KeyValuePair<string, double>>
                                                          {
                                                              new KeyValuePair<string, double>("Value1", 0.3),
                                                              new KeyValuePair<string, double>("Value2", 0.5),
                                                              new KeyValuePair<string, double>("Value3", 0.5),
                                                              new KeyValuePair<string, double>("Value1", 0.2),
                                                              new KeyValuePair<string, double>("Value2", 0.7)
                                                          };

            Random r = new Random();
            double diceRoll = r.NextDouble();

            double cumulative = 0.0;
            for (int i = 0; i < elements.Count; i++)
            {
                cumulative += elements[i].Value;
                if (diceRoll < cumulative)
                {
                    string selectedElement = elements[i].Key;
                    break;
                }
            }

        }
        public int BTshortestPath(BsNode n)
        {
            if (n == null)
            {
                return 0;
            }


            int leftHeight = BTshortestPath(n.GetLeft());
            int rightHeight = BTshortestPath(n.GetRight());
            int height;

            if (leftHeight > rightHeight)
            {
                height = rightHeight + 1;
            }
            else
            {
                height = leftHeight + 1;
            }
            return height;


        }

        public int NextHIghestNumber(int number)
        {

            List<int> numbers = new List<int>();
            // convert the given number into individual digits
            while (number != 0)
            {
                numbers.Add(number % 10);
                number /= 10;
            }
            //Reverse to get the digits in teh same order as the number
            numbers.Reverse();
            int length = numbers.ToArray().Length;
            int pointer;
            //loop from the end of the array, to find the first number that is descending 
            for (pointer = length - 1; pointer > 0; pointer--)
            {
                if (numbers[pointer - 1] > numbers[pointer])
                {
                    continue;
                }
                else
                    break;
            }
            if (pointer == 1)
                return 0;

            int nonAscendingNumber = numbers[pointer - 1];
            // capture the index of the number that is next to nonAscendingnumber
            // we can safely assume(fact) that the next number is the next highest 
            // number than the descending number
            int min = pointer;

            //Loop to find the minimum number that is higher than nonAscendingNumber
            //start the loop with index after the index of the 'min' i.e. pointer+1
            for (int i = pointer + 1; i < length; i++)
            {
                if (numbers[i] > nonAscendingNumber && numbers[i] < numbers[min])
                {
                    min = i; // capture the index of the number that is min.Higher than the nonAscendingNumber
                }

            }
            //Swap the numbers i.e. nonAscendingNumber and the min.Higher than the nonAscendingNumber
            int temp = numbers[pointer - 1];
            numbers[pointer - 1] = numbers[min];
            numbers[min] = temp;

            int[] arr = numbers.ToArray();
            //Sort the array from index after nonAscendingNumber to end of the array 
            Array.Sort(arr, pointer, length - pointer);

            foreach (int element in arr)
            {
                Console.Write(element + " ");
            }

            Console.ReadLine();
            return 0;
        }

        public void LongestSubStringWithMUniqueCharacters(string s, int m)
        {
            char[] input = s.ToCharArray();
            Dictionary<char, int> characterCount = new Dictionary<char, int>();
            int start = 0; int end = 0; int windowStart = 0; int windowSize = 1;
            characterCount.Add(input[0], 1);
            for (int i = 1; i < input.Length; i++)
            {
                if (characterCount.ContainsKey(input[i]))
                {
                    characterCount[input[i]]++;
                }
                else
                {
                    characterCount.Add(input[i], 1);
                }
                end++;
                while (!CheckforLengthM(characterCount, m))
                {
                    //characterCount.Remove(input[start]);
                    characterCount[input[start]]--;
                    start++; windowSize--;
                }
                if (end - start + 1 > windowSize)
                {
                    windowSize = end - start + 1;
                    windowStart = start;
                }
            }

            for (int i = start; i < windowStart + windowSize; i++)
            {
                Console.Write(" " + input[i] + " ");
            }
        }

        public bool CheckforLengthM(Dictionary<char, int> characterCount, int m)
        {
            int count = 0;
            foreach (var ch in characterCount)
            {
                if (ch.Value > 0)
                {
                    count++;
                }
            }

            return count <= m;
        }


        public void LargestSubsetWithConsecutiveNumbers(int[] arr)
        {
            Dictionary<int, int> collection = new Dictionary<int, int>();
            List<int> largestSubset = new List<int>();
            int count = 1; int nextDigit; int firstHighest = 0; int secondHighest = 0; int temp;
            int[] array = new int[0];

            for (int i = 0; i < arr.Length; i++)
            {
                collection.Add(arr[i], 0);
            }

            foreach (int digit in collection.Keys)
            {
                int startSeq = digit - 1;
                if (collection.ContainsKey(startSeq))
                {
                    continue;
                }
                else
                {

                    count = 1;
                    largestSubset.Add(digit);
                    nextDigit = digit + 1;

                    for (int i = 0; i < arr.Length; i++)
                    {

                        if (!collection.ContainsKey(nextDigit))
                        {
                            break;
                        }
                        else
                        {
                            largestSubset.Add(nextDigit);
                            nextDigit = nextDigit + 1;
                            count++;
                        }

                    }
                    secondHighest = count;
                    if (firstHighest < secondHighest)
                    {
                        temp = firstHighest;
                        firstHighest = secondHighest;
                        secondHighest = temp;

                        array = new int[largestSubset.Count];
                        largestSubset.CopyTo(array);
                    }

                    largestSubset.Clear();
                }

            }
            Console.Write("The largest subset of continous numbers: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }


        }

        public void ShortestRange(int[] arr1, int[] arr2, int[] arr3)
        {

            int length1 = arr1.Length;
            int length2 = arr2.Length;
            int length3 = arr3.Length;

            int minArray = Math.Min(length1, length2);
            //int minLength = Math.Min(length3,minArray);

            int min = 0; int max = 0; int range = 0;

            int j = 0; int q = 0; int i = 0;

            while (j < arr1.Length && i < arr2.Length && q < arr3.Length)
            {

                if (arr1[j] > arr2[i] && arr1[j] > arr3[q])
                {

                    max = arr1[j];

                }
                else if (arr2[i] > arr1[j] && arr2[i] > arr3[q])
                {
                    max = arr2[i];

                }
                else
                {

                    max = arr3[q];

                }

                if (arr1[j] < arr2[i] && arr1[j] < arr3[q])
                {

                    min = arr1[j];
                    _ = arr1[j++];
                }
                else if (arr2[i] < arr1[j] && arr2[i] < arr3[q])
                {

                    min = arr2[i];
                    _ = arr2[i++];

                }
                else
                {

                    min = arr3[q];
                    _ = arr3[q++];
                }

                range = max - min;

            }
            Console.WriteLine("Min Range is: " + range + " Max Element:  " + max + " Min Element : " + min);
            Console.ReadLine();
        }

        static int GetOddOccurrence(int[] arr, int arr_size)
        {
            int res = 0;
            for (int i = 0; i < arr_size; i++)
            {
                res = res ^ arr[i];
            }
            return res;
        }

        public void MaxElementFromSubArray(int k)
        {
            int[] myArr = { 9, 6, 11, 8, 10, 5, 4, 13, 93, 14 };
            List<int> NumbersInAsscOrder = new List<int>();
            NumbersInAsscOrder.Add(0); // Add the index of the fisrt element in the array
            int count = 0;
            // We will use Deque datastructure to solve the problem
            //DeQueue : Elements can be added from begining and removed from end

            //Check for the first 4(K) elements in the array
            //Step#1 Remove indices from the rear end of the list
            //for which array[j] is less than array[i]

            //Step#2 Add index i at the end of list

            for (int i = 1; i < k; i++)
            {
                if (myArr[i] < myArr[NumbersInAsscOrder.ElementAt(0)])
                {
                    NumbersInAsscOrder.Add(i);
                    count++;
                }
                else
                {
                    while (count >= 0)
                    {
                        NumbersInAsscOrder.Remove(count);
                        count--;
                    }
                    NumbersInAsscOrder.Add(i);
                }
            }

            for (int i = k; i < myArr.Length; i++)
            {
                //Step#1 print the first element in the list
                //the first elemnet in the list will always be the highest number in any sub-array
                Console.WriteLine(myArr[NumbersInAsscOrder.ElementAt(0)]);
                int check = NumbersInAsscOrder.ElementAt(0);
                //check for the subarray of size k
                //Step#2Remove index from the front-end of the list which wont be 
                //included in the current window of size K
                if (check < (i - k + 1))
                {
                    NumbersInAsscOrder.RemoveAt(0);
                }
                count = NumbersInAsscOrder.Count - 1;

                //Step#3Remove indices from the rear end of the list
                //for which array[j] is less than array[i]
                if (myArr[i] > myArr[NumbersInAsscOrder.ElementAt(count)])
                {
                    while (count >= 0 && myArr[i] > myArr[NumbersInAsscOrder.ElementAt(count)])
                    {
                        NumbersInAsscOrder.RemoveAt(count);
                        count--;
                    }

                }
                //Step#4 Add index i at the end of the list
                NumbersInAsscOrder.Add(i);

            }

            Console.Write(myArr[NumbersInAsscOrder.ElementAt(0)]);
            Console.ReadLine();
        }

        public void CountFrequencyOfArrayElement()
        {
            int[] arr = { 2, 3, 3, 2, 5 };
            int n = arr.Length;
            int[] frequencyArray = new int[n];

            for (int i = 0; i < n; i++)
            {

                frequencyArray[arr[i] - 1]++;
            }

            for (int i = 0; i < frequencyArray.Length; i++)
            {
                Console.WriteLine("Frequency of " + (i + 1) + " is " + frequencyArray[i]);
            }

            Console.ReadLine();

        }

        public void MaximumSizeSquareSubmatrixWithAllOnes(int[,] myArray)
        {

            int[,] matrix = new int[myArray.GetLength(0), myArray.GetLength(1)];
            int max = 0;

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i, j] = myArray[i, j];
                    }
                    else
                    {
                        if (myArray[i, j] == 0)
                        {
                            matrix[i, j] = 0;
                        }
                        else
                        {
                            int firstMin = Math.Min(matrix[i - 1, j - 1], matrix[i, j - 1]);
                            matrix[i, j] = Math.Min(firstMin, matrix[i - 1, j]) + 1;
                        }
                    }
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }

            Console.WriteLine("Max square sub matrix is :  " + max);
            Console.ReadLine();
        }

        public void KMPpatternMactching()
        {
            //char[] pattern = {'a','a','b','a','a','b','a','a','a'};
            char[] pattern = { 'a', 'b', 'c', 'a', 'b', 'y' };
            string s = "abxabcabcaby";
            char[] str = s.ToCharArray();
            int[] lps = new int[pattern.Length];
            int j = 0;
            for (int i = 1; i < pattern.Length;)
            {
                if (pattern[j] == pattern[i])
                {

                    lps[i] = j + 1;
                    j++; i++;
                }
                else
                {

                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                        i++;

                }
            }

            j = 0;
            int m = 0;

            while (m < str.Length && j < pattern.Length)
            {
                if (str[m] == pattern[j])
                {
                    m++; j++;
                }
                else
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else m++;
                }
            }
            if (j == pattern.Length)
                Console.WriteLine("Pattren found!!");
        }

        public int numWays(string message)
        {
            int msgLen = message.Length;
            if (msgLen == 0 || msgLen ==1)
            {
                return 1;
            }
            
            int count = 0;
            if (message.ElementAt(0) == '0')
            { return 0; }

            if (message.ElementAt(msgLen - 1) > '0')
                count = numWays(message.Substring(0, msgLen-1));
                
            if (message.ElementAt(msgLen - 2) <= '2'  && message.ElementAt(msgLen - 1) < '7')
               count += numWays(message.Substring(0,msgLen-2));

            return count;
        }

        public int numWaysDp(string message, int[] decodeCount)
        {
            for (int i=2; i <= message.Length; i++)
            {
                if (message.ElementAt(i-1) > '0')
                {
                    decodeCount[i] = decodeCount[i - 1];
                }
                if (message.ElementAt(i - 2) <= '2' && message.ElementAt(i - 1) < '7')
                {
                    decodeCount[i] =  decodeCount[i]  + decodeCount[i - 2];
                }
            }
            return decodeCount[message.Length];
        }


        static void Main(string[] args)
        {

            Program p = new Program();
            BsNode n1 = new BsNode(50);
            p.Add(n1);

            BsNode n2 = new BsNode(40);
            p.Add(n2);

            BsNode n3 = new BsNode(30);
            p.Add(n3);
            BsNode n4 = new BsNode(45);
            p.Add(n4);

            BsNode n5 = new BsNode(80);
            p.Add(n5);
            BsNode n6 = new BsNode(70);
            p.Add(n6);
            BsNode n7 = new BsNode(90);
            p.Add(n7);

            BsNode n8 = new BsNode(48);
            p.Add(n8);

            BsNode n9 = new BsNode(25);
            p.Add(n9);

            //BsNode n10 = new BsNode(100);
            //p.Add(n10);

            BsNode n11 = new BsNode(60);
            p.Add(n11);

            BsNode n12 = new BsNode(55);
            p.Add(n12);


            //p.InOrder(n1);
            //Console.ReadLine();
            //int path = p.BTshortestPath(n1);

            //Console.WriteLine(path);
            //Console.ReadLine();

            //p.IterrativeInOrderTraversal(n1);
            //Console.ReadLine();
            //p.Add(n1);
            //int[] arr = new int[] { 1, 2, 4, 2, 2 };
            //p.MajorityElementInArray(arr);

            //int[] arr = new int[] { 15,22,23,28,31,38,5,6,8,10,12};
            //int count = p.RotationCount(arr , arr.Length);
            //Console.WriteLine("Array is rotated : " + count + " times");

            //int[] arr = new int[] {40,10,20,5,45,50,65,90,35,25};
            //int peak = p.PeakElementInArray(arr,arr.Length);
            //Console.WriteLine("Peak element : " + peak);
            //Console.ReadLine();

            //p.FirstNonRepeatingCharacter("ADBCGHIEFKJLADTVDERFSWVGHQWCNOPENSMSJWIERTFB");

            //int[] arr = {1,5,5,1,2,3,4,2,1,2,1,2,3,2,4};
            //p.OddOccurenceOfNumberInArray(arr);

            //int[] arr = {7,1,4,0,2,8,6,3,5};
            //p.RainWaterTrapping(arr);

            //p.RadomNumberWithWeights();

            //FInd the next highest number
            // Given number : 1263 => 1326 , 30102 => 30120, 32841 => 34128, 4132 => 4213
            //p.NextHIghestNumber(30102);

            //Longest Substring With M Unique Characters
            //string s = "karappa";
            //p.LongestSubStringWithMUniqueCharacters(s,4);


            //Find the longest subset with consecutive numbers
            // fro 1,3,,8,14,4,10,2,11 = > 1,2,3,4
            //int[] arr = {1,3,8,9,4,10,2,11,12};
            //p.LargestSubsetWithConsecutiveNumbers(arr);
            //Console.ReadLine();


            //Given k lists of sorted integers. 
            //Find shortest range that includes one number from each of the k lists.
            //L1: - { 4, 10, 15, 24, 26}
            //L2: - { 0, 9, 12, 20 }
            //L3: - { 5, 18, 22, 30 }
            //Output: -  { 20,24}
            //int[] arr1 = { 4, 10, 15, 24, 26 };
            //int[] arr2 = { 0, 9, 12, 20 };
            //int[] arr3 = { 5, 18, 22, 30 };
            //p.ShortestRange(arr1,arr2,arr3);

            //int []arr = { 2, 3, 5, 4, 5, 2, 4, 3, 5, 2, 4, 4, 2 }; 
            //int n = arr.Length; 
            //Console.Write(GetOddOccurrence(arr, n)); 

            //If you are given an integer array and an integer 'k' as input, write a program
            //    to print elements with maximum values from each possible 
            //    sub - array(of given input array) of size 'k'.
            //    If the given input array is { 9, 6, 11, 8, 10, 5, 14, 13, 93, 14 } and for k = 4
            //    output should be 11, 11, 11, 14, 14, 93, 93

            //p.MaxElementFromSubArray(4);


            //p.CountFrequencyOfArrayElement();

            //Given a matrix of dimensions mxn having all entries as 1 or 0, 
            //find out the size of maximum size square sub - matrix with all 1s.
            //int[,] myArray;
            //myArray = new int[,] {
            //    { 1,1,0,1,1}, 
            //    { 0,1,1,1,1 },
            //    { 0,0,1,1,1 },
            //    { 1,1,1,1,1 },
            //    {0,1,1,1,0} };
            //p.MaximumSizeSquareSubmatrixWithAllOnes(myArray);

            //p.KMPpatternMactching();

            string s = "12321";
            int[] decodeCount = new int[s.Length +1];
            decodeCount[0] = 1; decodeCount[1] = 1;
            //int numOfWays = p.numWays(s);
            int numOfWays = p.numWaysDp(s,decodeCount);
            Console.WriteLine("Number of ways :   " +  numOfWays);
            Console.ReadLine();
           
        }
    }

}
