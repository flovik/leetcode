using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

internal class InvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return null;

        var temp = root.left;
        root.left = InvertTree(root.right);
        root.right = InvertTree(temp);
        return root;
    }

    private readonly Queue<TreeNode> nodeQueue = new();

    public TreeNode InvertTree2(TreeNode root)
    {
        if (root == null)
            return null;

        nodeQueue.Enqueue(root);
        while (nodeQueue.Count != 0)
        {
            var node = nodeQueue.Dequeue();
            var left = node.left;
            var right = node.right;
            node.left = right;
            node.right = left;

            if (left != null)
                nodeQueue.Enqueue(left);
            if (right != null)
                nodeQueue.Enqueue(right);
        }

        return root;
    }
}