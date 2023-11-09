using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class ReverseLinkedListEasy
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null)
            return null;

        var prev = new ListNode(head.val);
        var next = head.next;

        while (head != null && next != null)
        {
            head = next;
            next = head.next;
            head.next = prev;
            prev = head;
        }

        return prev;
    }
}