using System;

public class BSTNode

{
    public int data;
    public BSTNode Right;
    public BSTNode Left;

    public int getData()
    {
        return data;
    }
    public void setData(int data)
    {
        this.data = data;
    }
    public BSTNode getLeft()
    {
        return Left;
    }
    public void setLeft(BSTNode left)
    {
        this.Left = left;
    }
    public BSTNode getRight()
    {
        return Right;
    }
    public void setRight(BSTNode right)
    {
        this.Right = right;
    }
    
    public BSTNode(int data)
	{
        this.data = data;
       
     }
}
