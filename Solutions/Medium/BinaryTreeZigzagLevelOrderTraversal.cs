using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class BinaryTreeZigzagLevelOrderTraversal
{
    private readonly Queue<TreeNode> _tree = new();
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        if (root is null) return new List<IList<int>>();
            
        var result = new List<IList<int>>();
        _tree.Enqueue(root);
        var reverse = false;
        while (_tree.Count != 0)
        {
            int currentCount = _tree.Count;
            var levelList = new List<int>();
            for (int i = 0; i < currentCount; i++)
            {
                var node = _tree.Dequeue();
                if(node.left is not null) _tree.Enqueue(node.left);
                if(node.right is not null) _tree.Enqueue(node.right);

                levelList.Add(node.val);
            }

            if (reverse)
            {
                for (int i = 0, j = levelList.Count - 1; i < j; i++, j--)
                {
                    (levelList[i], levelList[j]) = (levelList[j], levelList[i]);
                }
                result.Add(levelList);
                reverse = false;
            }
            else
            {
                result.Add(levelList);
                reverse = true;
            }

        }

        return result;
    }
}