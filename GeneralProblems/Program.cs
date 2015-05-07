using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProblems
{
    
    class Vertex
    {
        public int data;
        public LinkedList<Vertex> neighbours;


    }
    class Edge
    {
        public Vertex node1;
        public Vertex node2;
    }

    
   
    

    class Program
    {
       public BSTree Root;
        public class BSTree
        {
            public BSTree left;
            public BSTree right;
            public int data;

        }

        private void PrintSpiral(int [,] MyArray, int Rows, int Columns)
        {

            int Top = 0; int Bottom = Rows - 1; int Left = 0; int Right = Columns - 1; int direction = 0;

            while(Top <= Bottom && Left <= Right )
            {
                if(direction == 0)
                { 
                    for (int i = Top; i <= Right; i++ )
                        Console.WriteLine(MyArray[Top, i]);
                    Top++;
                }
                else if(direction == 1)
                {
                    for (int i = Top; i <= Bottom; i++)
                        Console.WriteLine(MyArray[i,Right]);
                    Right--;
                    
                }
                else if(direction == 2)
                {
                    for (int i = Right; i >= Left; i--)
                        Console.WriteLine(MyArray[Bottom,i]);
                    Bottom--;
                   
                                    
                }
                else if(direction == 3)
                {
                    for (int i = Bottom; i >= Top; i--)
                        Console.WriteLine(MyArray[i,Left]);
                    Left++;
                    
                }
                direction = (direction + 1) % 4;
            
            }
        
        }

        private int lp(char[] MyCharArray, int i, int j)
        {
            if (i == j)
                return 1;

            if (MyCharArray[i] == MyCharArray[j] && i+1 == j)
                return 2;

            if (MyCharArray[i] == MyCharArray[j])
                return (lp(MyCharArray, i + 1, j - 1) + 2);

            //if (MyCharArray[i] != MyCharArray[j])
                return Math.Max(lp(MyCharArray, i + 1, j), lp(MyCharArray, i, j - 1));

            //return 0;


        }

        public void AuxilaryHead(BSTree node)
        {
            if (Root == null)
            {
                Root = node;
                return;
            }
            else
                AddNodeToBST(Root, node);
        
        }

        public void AddNodeToBST(BSTree Root ,BSTree  node)
        {

            BSTree current = Root;
            if(node.data < current.data )
            {

                if (current.left == null)
                {
                    current.left = node;
                    return;
                }
                current = current.left;
                 AddNodeToBST(current, node);
            }
            else if(node.data > current.data)
            {
                if (current.right == null)
                {
                    current.right = node;
                    return;
                }
                current = current.right;
                AddNodeToBST(current, node);
            }

        
        }

        public int  IsBalanced(BSTree root)
        {
            if (root == null)
                return 0;
            int leftHeight = IsBalanced(root.left);
            int RighHeight = IsBalanced(root.right);

            Console.WriteLine((Math.Max(leftHeight , RighHeight)+1));
            return (Math.Max(leftHeight , RighHeight)+1);
                    
        }

        public void CheckIfTwoNodesAreConnected(BSTree node2, BSTree node7, BSTree root)
        {
            bool check = NodeAvailbale(node2, root);
            if (!check)
            {
                Console.WriteLine("Did not find: " + node2.data);
                Console.ReadLine();
            }
            else
            {

                if (node2.data == node7.data)
                { 
                }
                else
                { 
                    
                    Queue<BSTree> Q = new Queue<BSTree>();
                    Q.Enqueue(node2);
                    while(Q.Count != 0)
                    {

                        BSTree current = Q.First();
                        if (current.left != null)
                            Q.Enqueue(current.left);
                        if (current.right != null)
                            Q.Enqueue(current.right);
                        BSTree CheckNode = Q.Peek();
                        if (CheckNode.data == node7.data)
                        {
                            Console.WriteLine("There is a Connection between " + node2.data + " and " + node7.data);
                            Console.ReadLine();
                            break;
                        }
                        Q.Dequeue();
                            
                
                    }
                   
                }
            } 
        }

        public bool NodeAvailbale(BSTree node2, BSTree root)
        {

            BSTree Current = root;
            if (Current == null)
                return false;

            if (node2.data < Current.data)
             return NodeAvailbale(node2, Current.left);
            else if (node2.data > Current.data)
             return   NodeAvailbale(node2, Current.right);
            else 
                return true;
                         

           
        }

        private void MaxSumSubArray(int [] Array)
        {
            int sum = 0;
            int ans = 0;

            for (int i = 0; i < Array.Length - 1; i++ )
            {

                sum = sum + Array[i];
                if (sum < 0)
                {
                    sum = 0;
                }
                ans = Math.Max(sum,ans);

            }

            Console.WriteLine("Sum of Max sub-array :  " + ans);
            Console.ReadLine();
        
        }

        private void DecimalToBinary(int number)
        {
           List<int> Binary  = new List<int>();
           int reminder;


            while (number > 0)
            {
                reminder = number % 2;
                Binary.Add(reminder);
                number = number / 2;
            }
          Binary.Reverse();

          foreach (int item in Binary)
          {
              Console.Write(item);
          }

          Console.ReadLine();
        }

        public bool PathSum(BSTree head, int sum) // check this problem Head condition need to be checked on what need to be returned
        {
            if (head == null)
                return false;

            if(head.left == null && head.right == null)
                return ((sum - (head.data))== 0);

            int subsum = sum - head.data;
            return(PathSum(head.left,subsum) || PathSum(head.right,subsum));
            
            
        
        }

        public void MergeArray(int [] ArrayA, int [] ArrayB, int Totlength)
        {
               int [] MergeArray = new int [Totlength];
               int LenMergeArray = 0;
               int LenOfArrayA =0;
               int LenOfArrayB = 0;
                
              while( LenOfArrayA < ArrayA.Length && LenOfArrayB < ArrayB.Length)
              {
                    if(ArrayA[LenOfArrayA] < ArrayB[LenOfArrayB])
                    {
                        MergeArray[LenMergeArray] = ArrayA[LenOfArrayA];
                        LenOfArrayA++;
                        LenMergeArray++;
                    
                    }
                    else //(ArrayA[LenOfArrayA] > ArrayB[LenOfArrayB])
                    { 
                        MergeArray[LenMergeArray] = ArrayB[LenOfArrayB];
                        LenOfArrayB++;
                        LenMergeArray++;
                    
                    }
              
            }
              if (LenOfArrayA < ArrayA.Length)
            {
                while (LenOfArrayA < ArrayA.Length)
                {
                    MergeArray[LenMergeArray] = ArrayA[LenOfArrayA];
                    LenMergeArray++;
                    LenOfArrayA++;

                }

            }
              if (LenOfArrayB < ArrayB.Length)
            {
                while (LenOfArrayB < ArrayB.Length)
                {
                    MergeArray[LenMergeArray] = ArrayB[LenOfArrayB];
                    LenMergeArray++;
                    LenOfArrayB++;

                }

            }

            for (int i = 0; i < MergeArray.Length; i++ )
            {
                Console.Write(MergeArray[i] + " ");
            }
            Console.ReadLine();
        
        }

        public BSTree LCABT(BSTree head, int a, int b)
        {

            if (head == null)
                return null;

            if (head.data == a || head.data == b)
                return head;

            BSTree left = LCABT(head.left, a, b);
            BSTree right = LCABT(head.right, a, b);

            if (left != null && right != null)
                return head;
            else if (left != null)
                return left;
            else if (right != null)
                return right;
            else
               return null;
        }

        public void MirrorBT(BSTree head)
        {
            if (head == null)
                return;
            ProcessBT(head);
            MirrorBT(head.left);
            MirrorBT(head.right);


        }
        public void ProcessBT(BSTree head)
        {
            if (head == null)
                return;

            BSTree temp;
            temp = head.left;
            head.left = head.right;
            head.right = temp;
        
        }

        public int ReplaceSum(BSTree head)
        {

            if (head == null)
                return 0;

            int left = ReplaceSum(head.left);
            int righ = ReplaceSum(head.right);
            return ProcessSum(head, left, righ);

           

        }

        public int ProcessSum (BSTree head, int left, int right)
        {
            int temp = head.data;

            head.data = left + right + temp;

            return head.data;

            // = left + right

            
        
        }

        public void QuickSort(int [] Myarray, int start, int end, int k)
        {
            
            if(start < end)
            {
               int index = Qindex(Myarray, start, end);
               if (index == k-1)
               {
                   Console.WriteLine(k + "th Smallest element is " + Myarray[index]);
               }

               QuickSort(Myarray, start, index -1, k );
               QuickSort(Myarray,index+1, end, k);

            }
      
        }
        public int Qindex(int[] Myarray, int start, int end)
        {

            int index = start;
            int pivot = Myarray[end];

            for (int i = start; i < end; i++ )
            {
                if (Myarray[i] <= pivot)
                {
                    int temp = Myarray[i];
                    Myarray[i] = Myarray[index];
                    Myarray[index] = temp;
                    index++;
                
                }
            }
            int tempr = Myarray[index];
            Myarray[index] = Myarray[end];
            Myarray[end] = tempr;

            return index;

           
        }

        public void CountSort(int[] A,int length)
        {
           // int [] Count = new int [length+1] ;

            int[] Count = new int[30];
            for (int i = 0; i <= length; i++  )
            {

                
                Count[A[i]] = Count[A[i]] +1;
            
            }

            for (int j = 0; j < Count.Length; j++ )
            {
                Console.Write(Count[j] + " ");
            }
            Console.ReadLine();
        }

        public void FistSecondHghestNumbers(int [] A)
        {
            int Fhighest = A[0];
            int Shighest = A[0];

            for (int i = 1; i < A.Length; i++ )
            {
                if(Shighest < A[i])
                {
                    Shighest = A[i];

                    if(Fhighest < Shighest)
                    {
                        int temp = Fhighest;
                        Fhighest = Shighest;
                        Shighest = temp;

                    }
                }

            }

            Console.WriteLine("First Highest  is: " + Fhighest + " Second Highest is: " + Shighest);
            Console.ReadLine();

        
        }
        // This porblem needs futher coding
        public bool FindString(char [,] MyArray,int x, int y,char [,] Solution)
        {

            int Rows = MyArray.GetLength(0);
            int Columns = MyArray.GetLength(1);

            Console.WriteLine("Rows :" + Rows + " Columns : " + Columns );
            Console.ReadLine();
            

            if(x== Rows-1 || y==Columns-1 )
           {
                
                
                return true;
           }
           bool flag = IsSafe(x,y, Rows, Columns, MyArray);

           if (flag)
           {
               Solution[x, y] = 'M';
               if (FindString(MyArray,x-1, y, Solution )) return true;
               if (FindString(MyArray, x+1, y, Solution)) return true;
               if (FindString(MyArray, x, y-1, Solution)) return true ;
               if (FindString(MyArray, x, y+1, Solution)) return true ;

               Solution[x, y] = 'Z';
               MyArray[x,y] = 'H';
               return false;
           
           }

           return false;
        
        }

        public bool IsSafe(int x, int y, int Rows, int Columns, char [,] MyArray)
        {

           if(x >0 && x < Rows && y >0  && y < Rows &&  MyArray[x,y] == 'Z' )
                        return true;
           return false;
    
        }


        public int BinarySearch(int [] B, int start, int end, int SearchKey)
        {


            if (start > end)

                return -1;
            
            int index = (start + end) / 2;



            if (SearchKey == B[index])
            {
                
                return index;
            }
            else if (SearchKey < B[index])
            {
               return BinarySearch(B, start, index, SearchKey);
            }
            else // if (SearchKey > B[index])
            {
               return BinarySearch(B, index + 1, end, SearchKey);
            }

           // return 0;
        }

        public void NonReccBinarySearch(int [] B, int start,  int End, int key)
        {

            //int index = (start + End) / 2;

            while(start < End)
            {
                int index = (start + End) / 2;
                if (key == B[index])
                {
                    Console.WriteLine("BinarySearch key is found at Index :  " + (index + 1) );
                    return;
                }
                else if(key < B[index])
                {
                    End = index -1;
                
                }
                else if (key > B[index])
                {
                    start = index +1;
                }

            }
            return ;
        
        
        }

        public void DeleteNodeFrmBST(BSTree node, int DeleteNode)
        {
            BSTree Previous = null;
            BSTree Delete = null;
            if (node == null)
                return;
           BSTree FoundPrevNode = FindNode(node, DeleteNode, Previous);
           if (FoundPrevNode.left.data == DeleteNode)
               Delete = FoundPrevNode.left;
           else
               Delete = FoundPrevNode.right;

            // Cae 1 : Left and Right leafs are null

           if (Delete.left == null && Delete.right == null)
               Delete = null;

            // Case 2 : Left Child & Right Child are present  and Right Child has Left Child

           if (Delete.right != null)
           {
               BSTree FRight =  Delete.right;
               BSTree current = FRight;
               BSTree Fleft = null;

               while(current.left != null)
               {
                   
                   current = current.left;
               
               }

               current.right= FRight;
               current.left = Delete.left;
               FoundPrevNode.left = current;//Fleft;
               
               Delete = null;
           }




                  
        }
        public BSTree FindNode( BSTree node ,int DeleteNode, BSTree Previous)
        {

            BSTree current = node;
            //BSTree Previous;

            if (current == null)
                return null;

            if (current.data == DeleteNode)
            {
                return (Previous);

            }
            else if (DeleteNode < current.data)
            {
                Previous = current;
                return FindNode(current.left, DeleteNode, Previous);
            }
            else if (DeleteNode > current.data)
            {
                Previous = current;
                return FindNode(current.right, DeleteNode, Previous);

            }
            else
            {
                return null;
            }



    
        }

        public int  LCABST(BSTree node, int a, int b)
        {
            if (node == null)
                return -1;

            if (node.data == a || node.data == b)
                return node.data;
            if (node.data > a && node.data < b || node.data < a && node.data > b)
                return node.data;
            if (node.data < a && node.data < b)
               return LCABST(node.right, a, b);
            if (node.data > a && node.data > b)
                return LCABST(node.left, a, b);
            else
                return -1;
            
            
            
        }

        public void PrintAllPaths(BSTree node, int [] MyArray, int count)
        {
            if (node == null)
                return;

            MyArray[count++] = node.data;

            if (node.left == null && node.right == null)
            {
                AuxPrint(MyArray, count);
            }
            else
            { 
                PrintAllPaths(node.left, MyArray, count);
                PrintAllPaths(node.right, MyArray,count);
            }
        
        }
        public void AuxPrint(int [] MyArray, int count)
        {
            for (int i = 0; i < count; i++)
            { 
                Console.Write(MyArray[i] +" ,");
            }
            Console.WriteLine();
            Console.ReadLine();

        }


        public int lcsDynamic(char [] str1, char [] str2, int l1, int l2)
        {
            if (l1 == str1.Length-1 || l2 == str2.Length-1)
                return 0;

            if (str1[l1] == str2[l2])
            {
                
                return 1 + lcsDynamic(str1, str2, l1 + 1, l2 + 1);
            }
            else
                return Math.Max(lcsDynamic(str1, str2, l1 + 1, l2), lcsDynamic(str1, str2, l1, l2 + 1));
    
        }

        public void RemoveDupilcates(string[] Mystrings)
        {
            List<string> uniqueStrings = new List<string>();

            foreach (string mystring in Mystrings)
            {
                if (!uniqueStrings.Contains(mystring))
                {
                    uniqueStrings.Add(mystring);
                }

            }
        
        }

        public void StockBuySell(int [] A)
        {
            int Alength = A.Length ;                  
            int []buy = new int[10];            
            int[] sell = new int[10];                     
            int count = 0;
            int j = 0;
            while (j < Alength-1)
            {
                while ((j < Alength-1) && (A[j + 1] <= A[j]))
                {
                    j++;

                }
                if (j == Alength - 1)
                    break;
                              
                buy[count] = A[j++];

                while((j < Alength-1) && (A[j+1] >= A[j]))
                {
                    j++;
                }
               
                sell[count] = A[j];
                count++;

            }

           
        }
       

        static void Main(string[] args)
        {

            //0. Print 2d array in spiral
            //int [,] MyArray = new int [4,4]  {
            //{0,1,2,3},
            //{4,5,6,7},
            //{8,9,10,11},
            //{12,13,14,15}};

            Program p = new Program();
            //p.PrintSpiral(MyArray,4,4); //Print Array in Spiral direction
            //Console.ReadLine();

            // 1.Longest palindromic sequence
           // string s = "GeeksforGeeks";
           // char[] MyChararray = s.ToCharArray();

           //int n = p.lp(MyChararray, 0, (MyChararray.Length -1));

           // Console.WriteLine("Length of the string is : ", n);
           // Console.ReadLine();

            //2. FInd the maximum sum sub-array

            //int[] Array = {1, -3, 2,-5,7,6,-1,-4,11,-23};
            //p.MaxSumSubArray(Array);


            LinkedList<Vertex> index = new LinkedList<Vertex>();

            //Vertex v1 = new Vertex();
            //v1.data = 10;

            //Vertex v2 = new Vertex();
            //v2.data = 20;

            
            

           

            //int indexofv2 = index.Count();
            //Console.WriteLine(indexofv2);
            //Console.ReadLine();

            //3. Converting number from Decimal to Binary
            //int number = 18;
            //p.DecimalToBinary(number);

           

            //4. Building tree and finding height and check if it is balanced

            BSTree node = new BSTree();
            node.data = 15;
            p.AuxilaryHead(node);
           

            BSTree node1 = new BSTree();
            node1.data = 10;
            p.AuxilaryHead(node1);

            BSTree node2 = new BSTree();
            node2.data = 20;
            p.AuxilaryHead(node2);

            BSTree node3 = new BSTree();
            node3.data = 8;
            p.AuxilaryHead(node3);

            BSTree node4 = new BSTree();
            node4.data = 12;
            p.AuxilaryHead(node4);

            BSTree node5 = new BSTree();
            node5.data = 25;
            p.AuxilaryHead(node5);

            BSTree node6 = new BSTree();
            node6.data = 17;
            p.AuxilaryHead(node6);

            BSTree node7 = new BSTree();
            node7.data = 6;
            p.AuxilaryHead(node7);


            BSTree node8 = new BSTree();
            node8.data = 11;
            p.AuxilaryHead(node8);

            BSTree node9 = new BSTree();
            node9.data = 16;
            p.AuxilaryHead(node9);

            BSTree node10 = new BSTree();
            node10.data = 27;
            p.AuxilaryHead(node10);

            #region
            //int diff = p.IsBalanced(node);
            //Console.WriteLine(diff);
            //Console.ReadLine();
            #endregion

            #region

           // //5. In a directed graph cjeck if two nodes are connected are not

           // BSTree node8 = new BSTree();
           // node8.data = 56;
           //// p.AuxilaryHead(node7);

           // p.CheckIfTwoNodesAreConnected(node2, node7, node);
            #endregion

            #region

            //// 6. To find if there is a path from root node of BST to any leaf whose sum is equal to given number
            //int sum = 49;
            //p.PathSum(node, sum);

            #endregion

            #region
            //7. Merge two sorted arrays

            //int [] ArrayA = {1,2,4,6};
            //int[] ArrayB = { 3, 5, 80, 82};

            //int Totlength = ArrayA.Length + ArrayB.Length ;

            //p.MergeArray(ArrayA, ArrayB, Totlength);
            #endregion

            #region
            //// 8. Find the least common ancestor in a binary tree
            //int a = 4;
            //int b = 7;
            //BSTree retvar = p.LCABT(node, a, b);
            //Console.WriteLine(retvar.data);
            //Console.ReadLine();
            #endregion

            ////9 . Mirror a Binary Tree : Approach Post_order Traversal Left, RIght, Data
            //p.MirrorBT(node);

            ////10. Replace nod with sum of chidren : Approach Post_order traversal Left, Right, Data

            //p.ReplaceSum(node);

            //11. Find the Kths smallest element in unsorted list

            //int[] Myarray = { 34,67, 23, 89, 6, 3, 82};
            //int Start = 0;
            //int end = Myarray.Length;
            //int k= 6;

            //p.QuickSort(Myarray, Start, end-1, k);

            //for (int i = 0; i < Myarray.Length; i++ )
            //{
            //    Console.Write(Myarray[i] + " ");
            //}

            //Console.ReadLine();

            //12. Counting sort (Unsolved Yet)

            //int[] A = { 4, 7, 3, 9, 6, 7, 8, 7, 8, 1,1, 10, 16, 9, 0 };

            //for (int i = 0; i < A.Length; i++)
            //{
            //    Console.Write(A[i] + " ");
            //}

            //p.CountSort(A,A.Length-1);


            //13. Finf first two highest numbers without sort

            //p.FistSecondHghestNumbers(A);

            //14. Find a string ("Microsoft") in the given matrix

            //char[,] MyArray = { {'A','C','M'}, {'D','E','F'},{'I','R', 'H'}, {'F', 'C', 'O'}, {'Z', 'S', 'N'}, {'O', 'T', 'Q'}  };

            //char[,] Solution = new char[3,6];
            //int x=0, y = 0;

            //p.FindString(MyArray,x,y,Solution);

            //15. Search a string in Sorted arrray

            //int [] B = {1,2,3,4,5,6,7,8,9,0};
            //int start = 0;
            //int end = B.Length -1;
            //int SearchKey = 2;

            // int searchIndex=  p.BinarySearch(B, start, end, SearchKey);

            // Console.WriteLine("Found key at Indiex  " + searchIndex + " Key is " + B[searchIndex]);
            // Console.ReadLine();

            //p.NonReccBinarySearch(B, start, end, SearchKey);


            //16 . Delete node from Binary treee
             //int DeleteNode = 10;
             //p.DeleteNodeFrmBST(node, DeleteNode);
             //int a = 6;
             //int b= 11;

             //p.LCABST(node, a, b);


            //17 . Print all paths in BST
            //int count = 0;
            //int[] MyArray = new int[10];             
            //p.PrintAllPaths(node, MyArray, count);

            //18. Remove dupilcates in a given string

            String [] Mystrings = new string []{"one", "two", "three", "one", "four", "two"};
            p.RemoveDupilcates(Mystrings);
           
            //19.Longest common SubSequence in two strings

            string str1 = "ABCDAF";
            string str2 = "ACBCF";
            int l1 = 0;
            int l2 =0;

           // int max = p.lcsDynamic(str1.ToCharArray(), str2.ToCharArray(), l1, l2);
            Console.ReadLine();

            // The cost of a stock on each day is given in an array, find the max profit that you can make by buying and selling in those days.
            //For example, if the given array is {100, 180, 260, 310, 40, 535, 695}, the maximum profit can earned by buying on day 0, selling on day 3. 
            //Again buy on day 4 and sell on day 6. If the given array of prices is sorted in decreasing order, then profit cannot be earned at all.

            int [] A = new int[] {100,180,260,310,40,535,695};
            // int[] A = new int[] { 48,31,61,38,51,70,10 };
            p.StockBuySell(A);
            
        }


    }
}
