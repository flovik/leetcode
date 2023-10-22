using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class ReverseLinkedList2
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var isFirst = left == 1;
        if (left == right) return head;

        var dummy = new ListNode(0, head);
        var prev = new ListNode();
        var first = head;
        var last = new ListNode();
        
        //move to the part where reversing should start
        int count = 1;
        while (count != left)
        {
            prev = first;
            first = first.next;
            count++;
        }

        var current = first;
        prev.next = current.next;
        while (left != right)
        {
            //first and last are used to keep track where the start is started to be reversed
            //prevCurrent and current are used to iterate the whole range in the linked list
            //prev saves the link to the future node that will be iterated in the list
            //change original link of the linked list

            var prevCurrent = current; 
            current = prev.next;

            //save link
            prev.next = current.next;
            current.next = prevCurrent;

            left++;
            if (left == right) last = current;
        }

        //set prev.next to the last node that was reversed
        first.next = prev.next; //prev has the reference to the next that first should point to
        prev.next = last;

        //edge case when left is one
        return isFirst ? prev.next : dummy.next;
    }
}