using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class SameTree
{
    private readonly Queue<TreeNode> _queue1 = new();
    private readonly Queue<TreeNode> _queue2 = new();

    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p == null && q == null)
            return true;

        _queue1.Enqueue(p);
        _queue2.Enqueue(q);

        while (_queue1.Count != 0 && _queue2.Count != 0)
        {
            var q1Node = _queue1.Dequeue();
            var q2Node = _queue2.Dequeue();

            if (q1Node is null && q2Node is null)
                continue;

            if (q1Node is null && q2Node is not null ||
                q1Node is not null && q2Node is null ||
                q1Node.val != q2Node.val)
                return false;

            _queue1.Enqueue(q1Node.left);
            _queue1.Enqueue(q1Node.right);
            _queue2.Enqueue(q2Node.left);
            _queue2.Enqueue(q2Node.right);
        }

        return _queue1.Count == 0 && _queue2.Count == 0;
    }
}