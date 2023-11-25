using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class BalancedBinaryTree
{
    private bool result = true;
    public bool IsBalanced(TreeNode root)
    {
        // A balanced binary tree will follow the following conditions:
        //
        // The absolute difference of heights of left and right subtrees at any node is less than 1.
        // For each node, its left subtree is a balanced binary tree.
        // For each node, its right subtree is a balanced binary tree.
        MaxDepth(root);
        return result;
    }

    private int MaxDepth(TreeNode root)
    {
        if (!result) return 0;

        if (root == null)
            return 0;

        var left = MaxDepth(root.left);
        var right = MaxDepth(root.right);

        // for each node check if their sub-trees are balanced
        if (Math.Abs(left - right) > 1)
            result = false;

        return 1 + Math.Max(left, right);
    }
}