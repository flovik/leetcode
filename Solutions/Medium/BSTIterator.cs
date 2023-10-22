using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class BSTIterator
{
    private Stack<TreeNode> stack = new Stack<TreeNode>();
    public BSTIterator(TreeNode root)
    {
        //add all nodes to the left of root (smallest)
        AddNewNodes(root);
    }

    public int Next()
    {
        //when a node is popped, its bigger children will be added
        //to the stack
        var temp = stack.Pop();
        AddNewNodes(temp.right);
        return temp.val;
    }

    public bool HasNext()
    {
        return stack.Count != 0;
    }

    private void AddNewNodes(TreeNode root)
    {
        while (root is not null)
        {
            stack.Push(root);
            root = root.left;
        }
    }
}