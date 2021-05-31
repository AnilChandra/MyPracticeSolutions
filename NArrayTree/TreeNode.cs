using System;
using System.Collections.Generic;
using System.Text;

namespace NArrayTree
{
    class TreeNode<T>
    {
        public T data;
        public List<TreeNode<T>> children;
        public TreeNode(T data)
        {
            this.data = data;
            children = new List<TreeNode<T>>();
        }

    }
}
