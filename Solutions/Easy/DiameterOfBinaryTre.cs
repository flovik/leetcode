using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class DiameterOfBinaryTre
{
    private int _diameter;

    public int DiameterOfBinaryTree(TreeNode root)
    {
        // max depth of left side of the tree + max depth of the right side of the tree for each node
        // dfs each node and see which has the largest diameter
        DfsWithMaxDepth(root);
        return _diameter;
    }

    private int DfsWithMaxDepth(TreeNode? root)
    {
        if (root == null)
            return 0;

        int left = DfsWithMaxDepth(root.left);
        int right = DfsWithMaxDepth(root.right);

        _diameter = Math.Max(_diameter, left + right);
        return 1 + Math.Max(left, right);
    }
}