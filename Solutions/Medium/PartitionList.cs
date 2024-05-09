using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class PartitionList
{
    public ListNode Partition(ListNode head, int x)
    {
        // nodes less than x to the left, all nodes greater than or equal to the right of x
        // preserve original relative order
        var cur = head;
        var less = new ListNode();
        var greater = new ListNode();
        var greaterStart = greater;
        var result = less;

        while (cur != null)
        {
            if (cur.val < x)
            {
                less.next = cur;
                less = less.next;

                cur = cur.next;
                less.next = null;
            }
            else
            {
                greater.next = cur;
                greater = greater.next;

                cur = cur.next;
                greater.next = null;
            }
        }

        less.next = greaterStart.next;
        return result.next;
    }
}