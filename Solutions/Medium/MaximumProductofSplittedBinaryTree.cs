using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class MaximumProductofSplittedBinaryTree
{
    public int MaxProduct(TreeNode root)
    {
        // consider every node as a subtree and compute it's sum
        // (totalSum - subTreeSum) * subTreeSum
        var sums = new List<int>();
        var totalSum = GetSum(root);
        var product = sums.Max(subTreeSum => subTreeSum * (long) (totalSum - subTreeSum));
        return (int) (product % 1_000_000_007);

        int GetSum(TreeNode treeNode)
        {
            if (treeNode is null)
                return 0;

            var sum = treeNode.val + GetSum(treeNode.left) + GetSum(treeNode.right);
            sums.Add(sum);
            return sum;
        }
    }
}