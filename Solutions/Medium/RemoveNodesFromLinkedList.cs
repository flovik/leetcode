using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class RemoveNodesFromLinkedList
{
    public ListNode RemoveNodes(ListNode head)
    {
        // remove every node which has a node with a greater value anywhere to the right side of it
        // descending

        head = ReverseLinkedList(head);

        var temp = new ListNode(0, head);

        while (head.next != null)
        {
            if (head.next.val < head.val)
            {
                var next = head.next;
                var nextNext = next.next;

                head.next = nextNext;
                next.next = null; // will be garbage collected
            }
            else head = head.next;
        }

        head = ReverseLinkedList(temp.next);
        return head;
    }

    private ListNode ReverseLinkedList(ListNode head)
    {
        ListNode prev = null;

        while (head != null)
        {
            var next = head.next;

            head.next = prev;
            prev = head;

            head = next;
        }

        return prev;
    }
}