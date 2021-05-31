using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NArrayTree
{
    class Program
    {
        public static int depth = 0;
        static void Main(string[] args)
        {
            //TreeNode<int> root = new TreeNode<int>(2);

            //TreeNode<int> node1 = new TreeNode<int>(3);
            //TreeNode<int> node2 = new TreeNode<int>(4);
            //TreeNode<int> node3 = new TreeNode<int>(5);
            //TreeNode<int> node4 = new TreeNode<int>(6);
            //TreeNode<int> node5 = new TreeNode<int>(7);
            //root.children.Add(node1);
            //root.children.Add(node2);
            //root.children.Add(node3);
            //node2.children.Add(node4);
            //node2.children.Add(node5);
            TreeNode<int> root = TakeInput();
            Print(root);
            int level = MaxDepthOfNarrayTree(root);
            Console.WriteLine("Max depth of N-Array Tree :  " + level);
            Console.ReadLine();

        }

        public static void Print(TreeNode<int> root)
        {
            string s = root.data + "= ";
            for (int i =0; i < root.children.Count; i++)
            {
                s = s + root.children.ElementAt(i).data + ", ";
            }
            Console.WriteLine(s);

            for (int i=0; i < root.children.Count; i++)
            {
                Print(root.children.ElementAt(i));
            }
            
        }
        public static TreeNode<int> TakeInput()
        {
            string val;
            Console.WriteLine("Enter Current root data : ");
            val = Console.ReadLine();
            int data = Convert.ToInt32(val);
            TreeNode<int> root = new TreeNode<int>(data);
            Console.WriteLine("How many children do you want :  ");
            val = Console.ReadLine();
            int _children = Convert.ToInt32(val);
            for(int i =0; i < _children; i++)
            {
                TreeNode<int> child = TakeInput();
                root.children.Add(child);
            }
            return root;
        }
        
        public static int MaxDepthOfNarrayTree(TreeNode<int> root)
        {
            if(root == null)
                return 0;
            HelperFunction(root, 1);
            return depth;
        }
        public static void HelperFunction(TreeNode<int> root, int level)
        {
            if (root == null)
                return;
            if (root.children.Count == 0)
                depth = Math.Max(depth,level);

            int _Children = root.children.Count;
            for(int i=0; i < _Children; i++)
            {
                HelperFunction(root.children.ElementAt(i),level+1);
            }
           
        }
    }
}
