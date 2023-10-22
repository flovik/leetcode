using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class RemoveDuplicatesFromSortedList2
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        var root = new ListNode(-101);
        var prev = new ListNode(-101, next: head);
        var prevPrev = new ListNode();
        var current = head;
        while (current is not null)
        {
            if (current.val != prev.val)
            {
                prevPrev = prev;
                prev = current;
                current = current.next;
                root.next ??= prev; //if root.next is null, assign prev, to return something in the end
            }
            else //found duplicate
            {
                //reset result value
                if (root.next is not null && root.next.val == current.val) root.next = null;
                //iterate current until the end or another node that is not duplicate
                while (current is not null && current.val == prev.val)
                    current = current.next;

                prevPrev.next = current;
                prev = prevPrev;
            }
        }



        return root.next;
    }
}