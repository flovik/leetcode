using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class SwapNodesInPairs
{
    public ListNode SwapPairs(ListNode head)
    {
        //no values modification
        //change nodes themselves

        //base cases
        if (head is null || head.next is null) return head;

        var dummy = new ListNode();
        //put the pointers to the right node (second one)
        dummy.next = head.next;

        //keep track of the previous node
        var previous = head;

        while (true)
        {
            var first = head;
            if(head is null) break;

            var second = head.next;
            if (second is null) break;

            var third = second.next;

            //1 now points to 4
            previous.next = second;
            //3 points to null
            first.next = third;
            //4 points to 3
            second.next = first;

            //4 is previous now
            previous = head;
            head = head.next;
        }

        return dummy.next;
    }
}