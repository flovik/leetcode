using Sandbox.DataStructures;

namespace Sandbox.Solutions.Hard;

public class MergeKSortedLists
{
    private readonly PriorityQueue<ListNode, int> _heap = new();

    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
            return null;

        // insert every node into a min heap
        foreach (var list in lists)
        {
            var node = list;
            while (node != null)
            {
                _heap.Enqueue(node, node.val);
                node = node.next;
            }
        }

        var cur = new ListNode();
        var res = cur;

        while (_heap.Count != 0)
        {
            cur.next = _heap.Dequeue();
            cur = cur.next;
        }

        cur.next = null;

        return res.next;
    }
}