using Sandbox.DataStructures;
using Sandbox.Topics.Trees;

namespace Sandbox.Solutions.Medium;

public class BinaryTreeLevelOrderTraversal2
{
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        var result = new LinkedList<IList<int>>();

        if (root is null)
            return result.ToList();

        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            var count = q.Count;
            var list = new List<int>(count);

            for (int i = 0; i < count; i++)
            {
                var cur = q.Dequeue();

                if (cur.left is not null)
                    q.Enqueue(cur.left);

                if (cur.right is not null)
                    q.Enqueue(cur.right);

                list.Add(cur.val);
            }

            result.AddFirst(list);
        }

        return result.ToList();
    }
}