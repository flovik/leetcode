using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class LowestCommonAncestorofaBinarySearchTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        int lowest, highest;

        if (p.val > q.val)
        {
            lowest = q.val;
            highest = p.val;
        }
        else
        {
            lowest = p.val;
            highest = q.val;
        }

        while (!(root.val <= highest && root.val >= lowest))
        {
            root = root.val > highest ? root.left : root.right;
        }

        return root;
    }
}