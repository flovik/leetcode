using Sandbox.DataStructures;

namespace Sandbox.Solutions.Hard;

public class ReverseNodesInKGroups
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var len = 0;
        var temp = head;

        // calculate length to know exactly how many iterations we would need
        while (temp != null)
        {
            temp = temp.next;
            len++;
        }

        return ReverseK(head, len / k);

        ListNode ReverseK(ListNode cur, int curIteration)
        {
            if (curIteration == 0)
                return cur;

            var (next, end, start) = Reverse(cur, k);
            end.next = ReverseK(next, curIteration - 1);
            return start;
        }
    }

    // returns (next, start, end) nodes
    private (ListNode, ListNode, ListNode) Reverse(ListNode head, int k)
    {
        var start = new ListNode { next = head };
        var next = head.next;

        while (next != null && k > 1)
        {
            var prev = head;
            head = next;

            next = head.next;
            head.next = prev;
            k--;
        }

        start.next.next = null;

        return (next, start.next, head);
    }
}