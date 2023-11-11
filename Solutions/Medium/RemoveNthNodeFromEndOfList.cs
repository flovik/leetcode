using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class RemoveNthNodeFromEndOfList
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var prev = new ListNode(0, head);
        var result = prev;

        var cur = head;
        var len = 0;
        while (cur != null)
        {
            cur = cur.next;
            len++;
        }

        n = len - n;

        while (n != 0)
        {
            head = head.next;
            n--;
        }

        var next = head.next;
        head.next = null;
        prev.next = next;

        return result.next;
    }
}