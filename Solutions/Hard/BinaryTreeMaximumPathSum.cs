using Sandbox.DataStructures;

namespace Sandbox.Solutions.Hard;

public class BinaryTreeMaximumPathSum
{
    private int _result = int.MinValue;

    public int MaxPathSum(TreeNode root)
    {
        // postOrder? go from leaf nodes up and compare left node with right node
        // at each iteration take the max(left.val, right.max)
        // we have two scenarios:
        // 1. take the max path from the current node as a ROOT (take both gains from left and right nodes, but DON'T change the nodes value)
        // by that, we take the left subtree and right subtree with their already computed max values
        // 2. going up the tree, we decide to take EITHER one of the branches (left, right or none) and we will have a new max in that node

        PostOrder(root);
        return _result;
    }

    private void PostOrder(TreeNode root)
    {
        if (root is null)
            return;

        PostOrder(root.left);
        PostOrder(root.right);

        // take max from current node
        var currentMax = root.val;
        int leftValue = 0, rightValue = 0;

        if (root.left is not null && root.left.val > 0)
            leftValue = root.left.val;

        if (root.right is not null && root.right.val > 0)
            rightValue = root.right.val;

        currentMax += leftValue + rightValue;

        if (currentMax > _result)
            _result = currentMax;

        root.val = Math.Max(root.val, Math.Max(root.val + leftValue, root.val + rightValue));
    }
}