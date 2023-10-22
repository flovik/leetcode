using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class ValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root)
    {
        //do inorder traversal, it will give the nodes in increasing order
        var stack = new Stack<TreeNode>();
        TreeNode prev = null;
        while (stack.Count != 0 || root != null)
        {
            if (root is not null)
            {
                stack.Push(root);
                root = root.left;
            }
            else
            {
                root = stack.Pop();
                if (prev is not null && root.val < prev.val) return false; 
                prev = root;
                root = root.right;
            }
        }

        return true;
    }
}