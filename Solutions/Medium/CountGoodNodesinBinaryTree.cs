using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class CountGoodNodesinBinaryTree
{
    public int GoodNodes(TreeNode root)
    {
        // traverse each node using BFS and change the node to the maximum seen (previous node) and count if it is good
        var result = 1;
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var node = queue.Dequeue();

            if (node.left != null)
            {
                if (node.left.val >= node.val)
                    result++;
                else
                    node.left.val = node.val;

                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                if (node.right.val >= node.val)
                    result++;
                else
                    node.right.val = node.val;

                queue.Enqueue(node.right);
            }
        }

        return result;
    }
}