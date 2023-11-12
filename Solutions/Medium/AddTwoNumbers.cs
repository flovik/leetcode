using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class AddTwoNumbers
{
    public ListNode AddTwoNumbersSolution(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        var prev = result;

        var memoryVal = 0;
        while (l1 != null || l2 != null)
        {
            var curVal = memoryVal;
            if (l1 != null)
            {
                curVal += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                curVal += l2.val;
                l2 = l2.next;
            }

            if (curVal >= 10)
                memoryVal = curVal / 10;
            else
                memoryVal = 0;

            result.next = new ListNode(curVal % 10);
            result = result.next;
        }

        // memory val
        if (memoryVal > 0)
            result.next = new ListNode(1);

        return prev.next;
    }
}