using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTree
{

    
    
    public class Program
    {
        BSTNode Head;
        int temp = 0;

        public void Add(BSTNode Node, int Data)
        {

            if (Head == null)
            {
                Head = Node;
            }
            else
            {
                BTSInsert(Head, Node);
            }

        }
        
        public void BTSInsert(BSTNode RHead, BSTNode NewNode)
        {

             BSTNode currentPtr = RHead;
            //BSTNode currentPtrPtr = currentPtr;


            if (NewNode.data <= currentPtr.data)
            {
                if (currentPtr.Left == null)
                {
                    currentPtr.Left = NewNode;
                    return;
                }
                else
                {
                    currentPtr = currentPtr.Left;
                    BTSInsert(currentPtr, NewNode);
                }
            }
            else 
            {
                if (currentPtr.Right == null)
                {
                    currentPtr.Right = NewNode;
                    return;
                }
                else
                {
                    currentPtr = currentPtr.Right;
                    BTSInsert(currentPtr, NewNode);
                }
            
            }    
      
        }

        public Boolean BSTSearch(BSTNode Head ,int SearchInput)
        {
            if (Head == null)
            {
                Console.WriteLine("Head itself is Null!!");
                return false;
            }
            
            else if (Head.data == SearchInput )
            {
                Console.WriteLine("Match Found!!!");
                return true;
            }
            else if (SearchInput <= Head.data)
            {
               return BSTSearch(Head.Left, SearchInput);
               
            }
            else// if (Head.data > SearchInput)
            {
               return BSTSearch(Head.Right, SearchInput);
               
            }
           
        
        }

        public BSTNode FindMin(BSTNode Head)
        {
                       
            if (Head == null)
            {
                return null;
            }
            while(Head.Left != null)
            {
                Head = Head.Left;
            }
            
            return Head;
        }

        public int FindBSTHeight(BSTNode Head)
        {
            if (Head == null)
            {
                return -1; // to count the number of nodes in a tree replace -1 with 0
               
            }

            int LeftHeight = FindBSTHeight(Head.Left);
            int RightHeight = FindBSTHeight(Head.Right); 

            //int LeftHeight = (FindBSTHeight(Head.Left) +1);
            //int RightHeight = (FindBSTHeight(Head.Right)+1);

            return (Math.Max(LeftHeight, RightHeight));

            //return (Math.Max(LeftHeight,RightHeight) +1);
            //return ((LeftHeight + RightHeight)+1); // to count the number of nodes in a tree excluding Root
        }

        public int FindMax(BSTNode Head)
        {
            int F;
            if (Head == null)
            {
                return -1;
            }
            else if(Head.Right == null)
            {
                return Head.data;
            }

            return F = FindMax(Head.Right);
            //Console.WriteLine(Head.Right);
        }

        public void LevelOrder(BSTNode Head)
        { 
            if (Head == null)
            { return; }

            Queue<BSTNode> Q = new Queue<BSTNode>();
            Q.Enqueue(Head);
            while(Q.Count()!= 0)
            {
                
                BSTNode Current = Q.First();
                Console.Write(Current.data + " ");
                if (Current.Left != null)
                {
                    Q.Enqueue(Current.Left);
                }
                if (Current.Right != null)
                {
                    Q.Enqueue(Current.Right);
                }
                Q.Dequeue();
            }
        
        }
        public void PreOrder(BSTNode Head)
        {
            if (Head == null)
            { return; }
            Console.Write(Head.data + " ");
            PreOrder(Head.Left);
            PreOrder(Head.Right);

        }

        public void InOrder(BSTNode Head)
        {
            if (Head == null)
            { return; }
            InOrder(Head.Left);
            Console.Write(Head.data + " ");
            InOrder(Head.Right);
        }
        public void CheckBST(BSTNode Head)
        {
           
            if (Head == null)
            { return; }
            CheckBST(Head.Left);
            Console.Write(Head.data + " ");
            if (temp > Head.data)
            {
                return;  
            }
            temp = Head.data;
            CheckBST(Head.Right);
        }
        public void PostOrder(BSTNode Head)
        {
            if (Head == null)
            { return; }
            PostOrder(Head.Left);
            PostOrder(Head.Right);
            Console.Write(Head.data +" ");
        }

        public BSTNode Delete(BSTNode Head, int Data)
        {

            if (Head == null)
            { return Head; }
            else if (Data < Head.Left.data)
            {
                Head.Left = Delete(Head.Left, Data);
            }
            else if (Data > Head.Right.data)
            {
                Head.Right = Delete(Head.Right, Data);
            }
            else
            { 
                if(Head.Left== null && Head.Right==null)
                {
                    Head = null;
                    return Head;
                }
                else if(Head.Left == null && Head.Right != null)
                {
                    BSTNode temp = Head;
                    Head = Head.Right;
                    temp = null;
                    return Head;
                }
                else if (Head.Right == null && Head.Left != null)
                {
                    BSTNode temp = Head;
                    Head = Head.Left;
                    temp = null;
                    return Head;
                }
                else
                {
                    BSTNode current = Head.Left;
                    BSTNode temp = FindMin(current.Right);
                    
                    current.data = temp.data;
                    Head.Right = Delete(current.Right, temp.data);
                    return Head;
                }
            }
            return Head;

        }
        BSTNode FindMinimum(BSTNode RightNode)
        {

            return RightNode;
        }

        BSTNode FindSuccessor(BSTNode Head, int data)
        {

            BSTNode Current =  FindNode(Head, data);
            if (Current == null)
                return null;

            //Case 1: When there is a right sub-tree find left mose node in right sub-tree
            if (Current.Right != null)
            {
                BSTNode temp = Current.Right;
                while (temp.Left != null)
                    temp = temp.Left;
                return temp;
            }
            else //case 2 : no right subtree (Nearest node for which given node will be in Left Subtree)
            {

                BSTNode Successor = null;
                BSTNode ancestor = Head;

                while(ancestor != Current)
                {
                    if(Current.data < ancestor.data)
                    {
                        Successor = ancestor;
                        ancestor = ancestor.Left;
                    }
                    else
                    ancestor = ancestor.Right;
                
                }
                return Successor;
            }
            


            return Head;
        }

        
        BSTNode FindNode(BSTNode Head, int data)
        {
           
            BSTNode Current = Head;

            while(Current != null)
            {

                if (data < Current.data)
                {
                    Current = Current.Left;
                
                }
                else if (data > Current.data)
                {
                    Current = Current.Right;
                }
                else
                {
                    return Current;
                }
            
            }
            return null;
        
        }

        static void Main(string[] args)
        {

            Program p = new Program();
            BSTNode node = new BSTNode();
            p.Add(node, node.data=15);

            BSTNode node1 = new BSTNode();
            p.Add(node1, node1.data=10);

            BSTNode node2 = new BSTNode();
            p.Add(node2, node2.data =20);

            BSTNode node3 = new BSTNode();
            p.Add(node3, node3.data =25);

            BSTNode node4 = new BSTNode();
            p.Add(node4, node4.data = 8);

            BSTNode node5 = new BSTNode();
            p.Add(node5, node5.data = 12);

            BSTNode node6 = new BSTNode();
            p.Add(node6, node6.data = 17);

            BSTNode node7 = new BSTNode();
            p.Add(node7, node7.data = 6);

            BSTNode node8 = new BSTNode();
            p.Add(node8, node8.data = 11);

            BSTNode node9 = new BSTNode();
            p.Add(node9, node9.data = 16);

            BSTNode node10 = new BSTNode();
            p.Add(node10, node10.data = 27);


            #region
            //p.BSTSearch(node, 8); //  search an elemnet in BST

            //int min =  p.FindMin(node); // Find min element in BST
            //Console.WriteLine("Minimum elemnet in the Tree : "+min);
            //Console.ReadLine();

            //int max = p.FindMax(node); // Find max element in BST
            //Console.WriteLine("Maximum element in the Tree : " + max);
            //Console.ReadLine();

            int Height = p.FindBSTHeight(node); // Find height of the trree leaving the leaf
            Console.WriteLine("Height of the Tree :  " + Height);
            Console.ReadLine();

            //Console.WriteLine("LevelOrder Traversal");
            //p.LevelOrder(node); // print the tree with leafs at the same level

            //Console.WriteLine();
            //Console.WriteLine("PreOrder Traversal");
            //p.PreOrder(node); // 1. Data 2. Left Tree 3. Right Tree (D,L,R)

            //Console.WriteLine();
            //Console.WriteLine("InOrder Traversal");
            //p.InOrder(node); // 1.Left 2. Data 3.Right (L,D,R)

            //Console.WriteLine();
            //Console.WriteLine("PostOrder Traversal");
            //p.PostOrder(node); // 1. Left 2. Right 3. Data (L,R,D)
            //Console.ReadLine();

            //Console.ReadLine();

            //p.CheckBST(node);
            //p.Delete(node, 10);

            #endregion

           // p.FindSuccessor(node, 25);


        }
    }
}
