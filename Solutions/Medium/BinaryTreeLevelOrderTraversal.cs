using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class BinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();

        if (root == null)
            return result;

        var treeQueue = new Queue<TreeNode>();

        var levelCount = 1;
        treeQueue.Enqueue(root);
        while (treeQueue.Count != 0)
        {
            var list = new List<int>();
            while (levelCount != 0)
            {
                var node = treeQueue.Dequeue();
                list.Add(node.val);

                if (node.left != null)
                    treeQueue.Enqueue(node.left);

                if (node.right != null)
                    treeQueue.Enqueue(node.right);

                levelCount--;
            }

            result.Add(list);
            levelCount = treeQueue.Count;
        }

        return result;
    }
}