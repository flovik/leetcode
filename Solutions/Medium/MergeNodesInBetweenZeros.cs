using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class MergeNodesInBetweenZeros
{
    public ListNode MergeNodes(ListNode head)
    {
        //modify zeros of the linked list to keep the sum
        //without allocating new memory
        var result = new ListNode();

        var currentZero = head;
        var current = head.next;
        int sum = 0;
        while (current is not null)
        {
            sum += current.val;
            current = current.next;
            if (current.val == 0)
            {
                result.next ??= currentZero; //save result
                currentZero.val = sum;
                sum = 0;
                //proceed to move currentZero to the next zero
                //if there are more nodes after that zero
                if (current.next is not null)
                {
                    currentZero.next = current;
                    currentZero = currentZero.next;
                }
                else
                {
                    //next is null so stop the iteration
                    //and return a clear result
                    currentZero.next = null;
                    break;
                }
            }
        }

        return result.next;
    }
}