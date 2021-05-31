using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTree
{

    

    public class Program
    {
        public BSTNode Head;
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

        

        public Boolean BSTSearch(BSTNode Head, int SearchInput)
        {
            if (Head == null)
            {
                Console.WriteLine("Head itself is Null!!");
                return false;
            }

            else if (Head.data == SearchInput)
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
            while (Head.Left != null)
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
            else if (Head.Right == null)
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
            Q.Enqueue(null);
            while (Q.Count() != 0)
            {

                BSTNode p = Q.Dequeue();
                if (p != null)
                {
                    Console.Write(p.data + ",");
                    if (p.Left != null)
                    {
                        Q.Enqueue(p.Left);
                    }
                    if (p.Right != null)
                    {
                        Q.Enqueue(p.Right);
                    }
                }
                //BSTNode pop =  Q.Dequeue();
                if (p == null)
                {
                    Console.WriteLine();
                    Q.Enqueue(null);
                    if( Q.Peek()== null)
                    break;
                }
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

        public List<int> InOrder(BSTNode Head , List<int> list)
        //public int[] InOrder(BSTNode Head, int[] list, int counter)
        {
            if (Head == null)
            { return list; }
            //InOrder(Head.Left);
            //Console.Write(Head.data + " ");
            //InOrder(Head.Right);

            InOrder(Head.Left, list);
            list.Add(Head.data);
            InOrder(Head.Right, list);
            return list;

            //InOrder(Head.Left, list, counter);
            //list[counter] = Head.data;
            //counter++;
            //InOrder(Head.Right, list, counter);
            //return list;
        }

        // This program is for creating a Balanced BST when a sorted array is given
        public BSTNode CreateBstFromSortedArray(int [] arr, int start, int end)
        {

            if (start > end || arr == null || arr.Length == 0)
                return null;
           
               
                int mid = (start + end) / 2;
                BSTNode root = new BSTNode(arr[mid]);
                root.setLeft(CreateBstFromSortedArray(arr, start, mid-1));
                root.setRight(CreateBstFromSortedArray(arr,mid+1,end));
                return root;
                       
        }

        public int DivIndex(int [] arr, int value, int start, int end)
        {
            int i;
            for ( i = start; i <= end; i++)
            {
                if (value < arr[i])
                    break;
            }

            return i;
        }

        // Create BST from pre-order array of nodes or Deserilize BST
        public BSTNode DeserealizeArray(int [] arr, int start, int end)
        {
            if (start > end)
                return null;
            BSTNode root = new BSTNode(arr[start]);
            int index = DivIndex(arr, arr[start], start+1, end);
            root.Left = DeserealizeArray(arr, start+1, index-1 );
            root.Right = DeserealizeArray(arr,index, end );
            return root;
        }


        public static void InOrderNew(BSTNode root)
        {
            if (root == null)
                return;

            InOrderNew(root.getLeft());
            Console.Write(root.data + "," );
            InOrderNew(root.getRight());
        }

        public void IterativeInOrder(BSTNode Head)
        {
            Stack<BSTNode> nodeStack = new Stack<BSTNode>();
            while (true)
            {
                while (Head != null)
                {
                    nodeStack.Push(Head);
                    Head = Head.Left;
                }
                if (nodeStack.Count == 0)
                {
                    break;
                }
                Head = nodeStack.Pop();
                Console.Write(Head.data + " ");
                Head = Head.Right;

            }
        }

        public void IterativePreOrder(BSTNode Head)
        {
            Stack<BSTNode> nodeStack = new Stack<BSTNode>();
            while (true)
            {
                while (Head != null)
                {
                    Console.WriteLine(Head.data);
                    nodeStack.Push(Head);
                    Head = Head.Left;
                }
                if (nodeStack.Count == 0)
                {
                    break;
                }

                Head = nodeStack.Pop();
                Head = Head.Right;

            }
        }

        public void IterativePostOrderTraversal(BSTNode node)
        {
            Stack<BSTNode> stackOfNodes = new Stack<BSTNode>();
            Stack<BSTNode> stackOfNodesForPostOrder = new Stack<BSTNode>();

            while (true)
            {
                while (node != null)
                {
                    
                    stackOfNodesForPostOrder.Push(node);
                    stackOfNodes.Push(node);
                    node = node.Right;
                }

                if (stackOfNodes.Count == 0)
                {
                    while (stackOfNodesForPostOrder.Count != 0)
                    {
                        BSTNode p = stackOfNodesForPostOrder.Pop();
                        Console.Write(p.data + ", ");
                    }

                    break;
                }

                node = stackOfNodes.Pop();
                node = node.Left;
            }

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
            Console.Write(Head.data + " ");
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
                if (Head.Left == null && Head.Right == null)
                {
                    Head = null;
                    return Head;
                }
                else if (Head.Left == null && Head.Right != null)
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

            BSTNode Current = FindNode(Head, data);
            if (Current == null)
                return null;

            //Case 1: When there is a right sub-tree find left most node in right sub-tree
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

                while (ancestor != Current)
                {
                    if (Current.data < ancestor.data)
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

        public void InOrderPredecessor(int data)
        {
            BSTNode p = FindNode(Head, data);
            BSTNode store = null;
            // When there is a left child to p
            if (p.Left != null)
            {
                BSTNode temp = p.Left;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
                Console.WriteLine(temp.data); // This also covers the case when there is no Right child
                Console.ReadLine();
                return;
            }
            // when p is the leaf node (search the node where it took the last right)
            if (p.Left == null || p.Right == null)
            {
                BSTNode current = Head;

                while (p.data != current.data)
                {
                    if (p.data <= current.data)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        store = current;
                        current = current.Right;
                    }
                }
                if (store != null)
                {
                    Console.WriteLine(store.data);
                    Console.ReadLine();
                }
                else Console.WriteLine(current.data); // when in-order predecessor is not present
                return;
            }

        }

        BSTNode FindNode(BSTNode Head, int data)
        {

            BSTNode Current = Head;

            while (Current != null)
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


        public void NumberOfBsTsWithNkeys(int keys)
        {
            int[] arr = new int[keys];
            arr[0] = arr[1] = 1;
            for (int i = 2; i < keys; i++)
            {
                arr[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    arr[i] = arr[i] + (arr[j] * arr[i - j - 1]);
                }
            }

            Console.WriteLine("No.of Binary trees possible are :  " + arr[arr.Length - 1]);
            Console.ReadLine();
        }

        public void DeleteNodeInBST(int node)
        {
            BSTNode current = Head;

            if (current == null)
            {
                return;
            }
            BSTNode location = null;
            BSTNode previous = null;
            while (current != null)
            {
                if (current.data == node)
                {
                    location = current;
                    break;
                }
                else if (node < current.data)
                {
                    previous = current;
                    current = current.Left;
                }
                else
                {
                    previous = current;
                    current = current.Right;
                }
            }

            // Case 1 : when both left and right are NULL i.e. leaf node
            if (location.Left == null && location.Right == null)
            {
                previous.Left = previous.Right = null;
            }

            // case 2 : when there are two children (find in-order successor)
            if (location.Left != null && location.Right != null)
            {
                BSTNode temp = null;
                if (location.Right != null)
                {
                    temp = location.Right;
                    while (temp.Left != null)
                    {
                        if (temp.Left != null)
                        {
                            previous = temp;
                        }
                        temp = temp.Left;
                    }
                }
                location.data = temp.data;
                if (temp.Left == null && temp.Right == null)
                {
                    previous.Right = previous.Left = null;
                    return;
                }
                if (temp.Left != null && temp.Right == null)
                {
                    previous.Left = temp.Left;
                    return;
                }
                if (temp.Right != null && temp.Left == null)
                {
                    previous.Right = temp.Right;
                    return;
                }

            }
            // case 3 : when there is only one child either Left or Right 
            if (location.Left != null && location.Right == null)
            {
                previous.Left = location.Left;
                return;
            }
            if (location.Right != null && location.Left == null)
            {
                previous.Right = location.Right;
                return;
            }

        }

        // Height of BT is also called as Maximum depth of BT
        public int HeightOfBst(BSTNode node)
        {

            if (node == null)
                return 0;

            int leftHeight = HeightOfBst(node.Left);
            int rightHeight = HeightOfBst(node.Right);
            int height;

            if (leftHeight > rightHeight)
            {
                height = leftHeight + 1;
            }
            else {
                height = rightHeight + 1;
            }
            return height;
        }

        public int DiameterofBinaryTree(BSTNode node)
        {
            if (node == null)
                return 0;

            int heightOfLeftTree = HeightOfBst(node.Left);
            int heightOfRightTree = HeightOfBst(node.Right);

            int leftDiameter = DiameterofBinaryTree(node.Left);
            int rightDiameter = DiameterofBinaryTree(node.Right);

            int diameter = Math.Max((heightOfLeftTree + heightOfRightTree + 1), Math.Max(leftDiameter, rightDiameter));

            return diameter;
        }

        public void RootToLeafPathForGivenSum(int sum, int sumToCurrentNode ,BSTNode node, Stack<int> nodeStack)
        {
            if (node == null)
                return;
            sumToCurrentNode = sumToCurrentNode + node.data;
            nodeStack.Push(node.data);
            if (sum == sumToCurrentNode)
            {
                // Print stack
                Console.WriteLine("---");
                foreach (int value in nodeStack)
                {
                    
                    Console.WriteLine(value);
                    Console.WriteLine("|");
                }
                Console.WriteLine("---");
            }
            RootToLeafPathForGivenSum(sum, sumToCurrentNode , node.Left , nodeStack);
            RootToLeafPathForGivenSum(sum, sumToCurrentNode, node.Right , nodeStack);
            sumToCurrentNode = sumToCurrentNode - node.data;
            nodeStack.Pop();
        }

        public int NodesHavingKleaves(BSTNode node , int k)
        {

            if (node == null)
            {
                return 0;
            }
            if (node.Left == null && node.Right == null )
            {
                return 1;
            }

            int leftCount = NodesHavingKleaves(node.Left , k);
            int rightCount = NodesHavingKleaves(node.Right, k);

            int totalCountOfLeaves = (leftCount + rightCount);

            if (totalCountOfLeaves == k)
                Console.WriteLine(node.data);

            return totalCountOfLeaves;
        }

        public BSTNode LeastCommonAncestorofBT(BSTNode _rootnode, BSTNode p, BSTNode q, BSTNode left, BSTNode right)
       // public BSTNode LeastCommonAncestorofBT(BSTNode _rootnode, BSTNode p, BSTNode q)
        {

            if (_rootnode == null)
                return null;
            if (_rootnode.data == p.data || _rootnode.data == q.data)
                return _rootnode;

            left = LeastCommonAncestorofBT(_rootnode.Left, p, q, left, right);
            right = LeastCommonAncestorofBT(_rootnode.Right, p, q, left, right);

            //BSTNode left = LeastCommonAncestorofBT(_rootnode.Left, p, q);
            //BSTNode right = LeastCommonAncestorofBT(_rootnode.Left, p, q);

            if (left != null && right != null)
                return _rootnode;
            //else
            //    return (left != null) ? left : right;
            else if (left != null)
                return left;
            else
                return right;
           
        }

        class obj
        {
            public BSTNode node;
            public int dis;
            public obj(BSTNode node, int dis)
            {
                this.node = node;
                this.dis = dis;
            }
        }
        public void VerticalOrderTravsersal(BSTNode node)
        {
            if (node == null)
                return;
            else
            {

                SortedDictionary<int, List<BSTNode>> disMap = new SortedDictionary<int, List<BSTNode>>();
            

                List<obj> queue = new List<obj>();
                queue.Add(new obj(node, 0));

                while (queue.Count > 0)
                {
                    obj element = queue.ElementAt(0);
                   
                    queue.RemoveAt(0);
                    
                    if (disMap.ContainsKey(element.dis))
                    {
                        disMap[element.dis].Add(element.node);
                    }
                    else
                    {
                        disMap[element.dis] = new List<BSTNode>() { element.node };
                    }
                    if (element.node.Left != null)
                    {
                        queue.Add(new obj(element.node.Left, element.dis -1));
                    }
                    if (element.node.Right != null)
                    {
                        queue.Add(new obj(element.node.Right, element.dis + 1));
                    }
                }

                foreach (int dis in disMap.Keys)
                {
                    List<BSTNode> nodeList = disMap[dis];
                    Console.Write(dis + ": ");
                    foreach (BSTNode n in nodeList)
                    {
                        Console.Write($" {n.data},");
                    }
                    //var lastItem = nodeList.LastOrDefault();
                    //Console.Write(lastItem.data);
                    Console.WriteLine();
                }

            }
        }


        public void BottomViewOfBinaryTree(BSTNode node)
        {
            if (node == null)
                return;
            else
            {
                Dictionary <int, BSTNode> map = new Dictionary<int , BSTNode>();
                List<obj> q = new List<obj>();
                q.Add (new obj(node,0));

                while (q.Count != 0)
                {
                    obj ele = q.ElementAt(0);
                    q.RemoveAt(0);
                    map[ele.dis] = ele.node;
                    
                    if (ele.node.Left != null)
                    {
                        q.Add(new obj(ele.node.Left, ele.dis-1));
                    }
                    if (ele.node.Right != null)
                    {
                        q.Add(new obj(ele.node.Right, ele.dis+1));
                    }
                }
                foreach (int dist in map.Keys)
                {
                    Console.Write($" {map[dist].data} , ");
                }

            }

        }

        public void TopViewOfBinaryTree(BSTNode node)
        {
            if (node == null)
                return;
            else {
                
                SortedDictionary<int, BSTNode> map = new SortedDictionary<int, BSTNode>();
                Queue<obj> levelOrderQueue = new Queue<obj>();
                levelOrderQueue.Enqueue(new obj(node, 0));

                while (levelOrderQueue.Count > 0)
                {
                    obj pop = levelOrderQueue.Dequeue();

                    if (!map.ContainsKey(pop.dis))
                    {
                        map[pop.dis] = pop.node;
                    }
                    if (pop.node.Left != null)
                    {
                        levelOrderQueue.Enqueue(new obj (pop.node.Left, pop.dis -1));
                    }
                    if (pop.node.Right != null)
                    {
                        levelOrderQueue.Enqueue(new obj(pop.node.Right, pop.dis +1));
                    }
                }

                foreach (int dist in map.Keys)
                {
                    Console.Write($" {map[dist].data} , ");
                }

            }
        }

        public void DiagonalSumInBinaryTree(BSTNode p)
        {
            Queue<BSTNode> QofLeftNodes = new Queue<BSTNode>();
            QofLeftNodes.Enqueue(p);
            QofLeftNodes.Enqueue(null);
            int sum = 0;
            while (QofLeftNodes.Count != 0)
            {
                p = QofLeftNodes.Dequeue();
                if (p == null)
                {
                    Console.Write(" = " + sum);
                    QofLeftNodes.Enqueue(null);
                    p = QofLeftNodes.Dequeue();
                    if(p==null)
                    { break; }
                    Console.WriteLine();
                    sum = 0;
                }
                
                
                while (p != null)
                {
                    Console.Write(p.data + "+");
                    sum = sum + p.data;
                    
                    if (p.Left != null)
                    {
                        QofLeftNodes.Enqueue(p.Left);
                    }
                    p = p.Right;
                }
                

            }
        }

        public void LeftSideViewOfBinaryTree(BSTNode p)
        {

            Queue<BSTNode> levelOrderQueue = new Queue<BSTNode>();
            //int _qCount = 0;
            levelOrderQueue.Enqueue(p);
            while (levelOrderQueue.Count != 0)
            {
                int count = levelOrderQueue.Count;
                int _qCount = levelOrderQueue.Count;
                while (count > 0)
                {
                    BSTNode pop = levelOrderQueue.Dequeue();
                    if (_qCount == count)
                    {
                        Console.Write(pop.data + " ");
                    }
                    if (pop.Left != null)
                        levelOrderQueue.Enqueue(pop.Left);
                    if (pop.Right != null)
                        levelOrderQueue.Enqueue(pop.Right);
                    count--;
                }
            }

        }

        public void RightSideViewOfBinaryTree(BSTNode p)
        {

            Queue<BSTNode> levelOrderQueue = new Queue<BSTNode>();
           
            levelOrderQueue.Enqueue(p);
            while (levelOrderQueue.Count != 0)
            {
                int count = levelOrderQueue.Count;
               
                while (count > 0)
                {
                    BSTNode pop = levelOrderQueue.Dequeue();
                  
                    if (count == 1)
                    {
                        Console.Write(" " +pop.data);
                    }
                    if (pop.Left != null)
                        levelOrderQueue.Enqueue(pop.Left);
                    if (pop.Right != null)
                        levelOrderQueue.Enqueue(pop.Right);
                    count--;
                }
            }

        }

        public void RootToLeafPathsOfBinaryTree(BSTNode p, Stack<BSTNode> paths)
        {
            if (p == null)
                return;

            paths.Push(p);
                
            RootToLeafPathsOfBinaryTree(p.Left, paths);
            RootToLeafPathsOfBinaryTree(p.Right, paths);
            if (p.Left == null && p.Right == null)
            {
                foreach (BSTNode node in paths)
                {
                    Console.Write(node.data + " ");
                }
                Console.WriteLine();
            }
            paths.Pop();
        }

        public int SumOfAllNodes(BSTNode node)
        {

            if (node == null)
                return 0;
            int sum = node.data + SumOfAllNodes(node.Left) + SumOfAllNodes(node.Right);
            return sum;

        }

        public int CheckIfBTisSumTree(BSTNode node)
        {
            if (node == null)
                return 0;
            if (node.Left == null && node.Right == null) // if leaf node return 1 i.e. always true for leaf node
                return 1;

            int left = SumOfAllNodes(node.Left);
            int right = SumOfAllNodes(node.Right);

            if (node.data == left + right)
            {

               
                int lefts = CheckIfBTisSumTree(node.Left);
                int rights = CheckIfBTisSumTree(node.Right);
                if(node.data == lefts + rights)    
                return 1;
            }

            return 0;
        }

        public int CheckIfTwoBinaryTreesAreIdentical(BSTNode firstTree , BSTNode secondTree)
        {
            if (firstTree == null && secondTree == null) // both are null trees
            {
                return 1; // return true
            }
            if (firstTree != null && secondTree != null)
            {
                if (firstTree.data == secondTree.data)
                {
                    CheckIfTwoBinaryTreesAreIdentical(firstTree.Left, secondTree.Left);
                    CheckIfTwoBinaryTreesAreIdentical(firstTree.Right, secondTree.Right);
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public int CheckIfTreeisSubtreeOfAnotherTree(BSTNode MainTree, BSTNode SubTree)
        {
            if (SubTree == null)
                return 1; // true

            if (MainTree == null)
                return 0; // false main tree is not present

            int check = CheckIfTwoBinaryTreesAreIdentical(MainTree , SubTree);
            if (check == 1) return 1;

            //return CheckIfTreeisSubtreeOfAnotherTree(MainTree.Left, SubTree) || CheckIfTreeisSubtreeOfAnotherTree(MainTree.Right, SubTree);

            CheckIfTreeisSubtreeOfAnotherTree(MainTree.Left, SubTree);
            CheckIfTreeisSubtreeOfAnotherTree(MainTree.Right, SubTree);
            return 0;
        }

        public int PrintAllAncestorsOfNodeInBT(BSTNode p , BSTNode target )
        {
            if (p != null)
            {
                if (p.data == target.data)
                    return 1;

                int leftReturn = PrintAllAncestorsOfNodeInBT(p.Left, target);
                int rightReturn = PrintAllAncestorsOfNodeInBT(p.Right, target);
                if (leftReturn == 1 || rightReturn == 1)
                {
                    Console.WriteLine(p.data);
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        static void Main(string[] args)
        {

            Program p = new Program();
            //BSTNode root = new BSTNode(50);
            //BSTNode node = new BSTNode();
            //p.Add(node, node.data=50);

            //BSTNode node1 = new BSTNode();
            //p.Add(node1, node1.data=16);

            //BSTNode node2 = new BSTNode();
            //p.Add(node2, node2.data =90);

            //BSTNode node3 = new BSTNode();
            //p.Add(node3, node3.data =14);

            //BSTNode node4 = new BSTNode();
            //p.Add(node4, node4.data = 40);

            //BSTNode node5 = new BSTNode();
            //p.Add(node5, node5.data = 78);

            //BSTNode node6 = new BSTNode();
            //p.Add(node6, node6.data = 100);

            //BSTNode node7 = new BSTNode();
            //p.Add(node7, node7.data = 10);

            //BSTNode node8 = new BSTNode();
            //p.Add(node8, node8.data = 15);

            //BSTNode node9 = new BSTNode();
            //p.Add(node9, node9.data = 35);

            //BSTNode node10 = new BSTNode();
            //p.Add(node10, node10.data = 45);

            //BSTNode node11 = new BSTNode();
            //p.Add(node11, node11.data = 75);

            //BSTNode node12 = new BSTNode();
            //p.Add(node12, node12.data = 82);

            //BSTNode node21 = new BSTNode();
            //p.Add(node21, node21.data = 105);

            //BSTNode node13 = new BSTNode();
            //p.Add(node13, node13.data = 5);

            //BSTNode node14 = new BSTNode();
            //p.Add(node14, node14.data = 32);

            //BSTNode node15 = new BSTNode();
            //p.Add(node15, node15.data = 36);

            //BSTNode node16 = new BSTNode();
            //p.Add(node16, node16.data = 81);

            //BSTNode node17 = new BSTNode();
            //p.Add(node17, node17.data = 85);

            //BSTNode node18 = new BSTNode();
            //p.Add(node18, node18.data = 37);

            //BSTNode node19 = new BSTNode();
            //p.Add(node19, node19.data = 79);

            //BSTNode node20 = new BSTNode();
            //p.Add(node20, node20.data = 87);


            #region
            //Deleting node from BST
            //p.InOrder(node);
            //Console.ReadLine();
            //p.DeleteNodeInBST(100);
            //p.InOrder(node);
            //Console.ReadLine();
            #endregion

            //p.InOrderPredecessor(5);

            // p.NumberOfBsTsWithNkeys(7);
            //p.IterativeInOrder(node);
            //Console.ReadLine();

            #region
            //p.BSTSearch(node, 8); //  search an elemnet in BST

            //int min =  p.FindMin(node); // Find min element in BST
            //Console.WriteLine("Minimum elemnet in the Tree : "+min);
            //Console.ReadLine();

            //int max = p.FindMax(node); // Find max element in BST
            //Console.WriteLine("Maximum element in the Tree : " + max);
            //Console.ReadLine();

            //int Height = p.FindBSTHeight(node); // Find height of the trree leaving the leaf
            //Console.WriteLine("Height of the Tree :  " + Height);
            //Console.ReadLine();

            //Console.WriteLine("LevelOrder Traversal");
            // p.LevelOrder(node); // print the tree with leafs at the same level

            //Console.WriteLine();
            //Console.WriteLine("PreOrder Traversal");
            //p.PreOrder(node); // 1. Data 2. Left Tree 3. Right Tree (D,L,R)

            //Console.WriteLine();
            //Console.WriteLine("InOrder Traversal");

            // Converting BST into List or a doubly linked list
            //List<BSTNode> list = new List<BSTNode>();
            List<int> list = new List<int>();
            //int[] list = new int[] { };
            //int count = 0;
            //list = p.InOrder(node, list); // 1.Left 2. Data 3.Right (L,D,R)
            //foreach (var listItem in list)
            //{
            //    Console.Write(listItem + " ,");
            //}
            //for (int i = 0; i < list.Length; i++)
            //{ Console.Write(list[i] + " ,"); }

            //Console.ReadLine();
            //int[] arr = new int[] {2,3,4,5,6,7,8};
            //BSTNode node =  p.CreateBstFromSortedArray(arr,0,arr.Length-1);
            //InOrderNew(node);
            //Console.ReadLine();

            int[] arr = new int[] { 5, 2, 1, 3, 4, 7, 6, 8 }; // pre-ordered array
            BSTNode node = p.DeserealizeArray(arr,0,arr.Length-1);
            p.PreOrder(node);
            Console.ReadLine();

            //Console.WriteLine();
            //Console.WriteLine("PostOrder Traversal");
            //p.PostOrder(node); // 1. Left 2. Right 3. Data (L,R,D)
            //Console.ReadLine();

            //Console.ReadLine();

            //p.CheckBST(node);
            //p.Delete(node, 10);

            #endregion

            // p.FindSuccessor(node, 25);

            // Find Height of BST 

            //int h = p.HeightOfBst(node);
            //Console.WriteLine(h);
            //Console.ReadLine();

            // Diamter of Binarytree
            // longest path in any given tree inluding the root or excluding teh root
            //int diameter = p.DiameterofBinaryTree(node);
            //Console.WriteLine(diameter);
            //Console.ReadLine();

            //Print Root to Leaf (not really leaf, any node where it ends with that sum) path with given sum
            //int sum = 90;
            //int sumToCurrentNode = 0;
            //Stack<int> nodeStack = new Stack<int>();
            //p.RootToLeafPathForGivenSum(sum, sumToCurrentNode, node, nodeStack);
            //Console.ReadLine();
            //Print Root to Leaf (not really leaf, any node where it ends with that sum) path with given sum

            //Print nodes having K (K is number of leaves) leaves
            //int leavesFromRoot = p.NodesHavingKleaves(node, 3);
            //Console.WriteLine("Leaves from root :" + leavesFromRoot);
            //Console.ReadLine();


            //Find least coomon ancestor of two given nodes in binary tree / BST
            //BSTNode left = null;
            //BSTNode right = null;
            //BSTNode _lca = p.LeastCommonAncestorofBT(node, node14, node18, left, right);
            //BSTNode _lca = p.LeastCommonAncestorofBT(node, node7, node10);
            //Console.WriteLine("Least common ancestor is :" + _lca.data);
            //Console.ReadLine();


            //Vertical order traversal i.e. find horizontal distance from access of each node and print them
            //p.VerticalOrderTravsersal(node);
            //Console.ReadLine();

            //Bottom view of BinaryTree/BST
            //p.BottomViewOfBinaryTree(node);
            //Console.ReadLine();

            //p.DiagonalSumInBinaryTree(node);
            //Console.ReadLine();

            // Side View of BT/BST Go Left and Right call 2 different functions
            //p.LeftSideViewOfBinaryTree(node);
            //Console.WriteLine();
            //p.RightSideViewOfBinaryTree(node);
            //Console.ReadLine();

            //Top View of BT/BST
            //p.TopViewOfBinaryTree(node);
            //Console.ReadLine();

            //Stack<BSTNode> paths = new Stack<BSTNode>();
            //p.RootToLeafPathsOfBinaryTree(node, paths);
            //Console.ReadLine();

            //int sum = p.SumOfAllNodes(node);
            //Console.WriteLine(sum);
            //Console.ReadLine();

            //p.PrintAllAncestorsOfNodeInBT(node, node18);

            //p.IterativePostOrderTraversal(node);
            //Console.ReadLine();


        }
    }
}
