using System.Collections;
using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class AddTwoNumbers2
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int size1 = 0, size2 = 0;
        var dummy1 = new ListNode(0, l1);
        var dummy2 = new ListNode(0, l2);
        var stackBig = new Stack<ListNode>();
        var stackSmall = new Stack<ListNode>();
        var finalResult = new Stack<ListNode>();

        while (dummy1.next is not null)
        {
            dummy1 = dummy1.next;
            size1++;
        }

        while (dummy2.next is not null)
        {
            dummy2 = dummy2.next;
            size2++;
        }

        dummy1 = new ListNode(0, l1); 
        dummy2 = new ListNode(0, l2);
        if (size1 > size2)
        {
            while (dummy1.next is not null)
            {
                dummy1 = dummy1.next;
                stackBig.Push(dummy1);
            }

            while (dummy2.next is not null)
            {
                dummy2 = dummy2.next;
                stackSmall.Push(dummy2);
            }
        }
        else
        {
            while (dummy1.next is not null)
            {
                dummy1 = dummy1.next;
                stackSmall.Push(dummy1);
            }

            while (dummy2.next is not null)
            {
                dummy2 = dummy2.next;
                stackBig.Push(dummy2);
            }
        }

        var takeNext = false;

        while (stackSmall.Count != 0)
        {
            var nodeBig = stackBig.Pop();
            var nodeSmall = stackSmall.Pop();
            nodeSmall.next = null;

            var sum = nodeBig.val + nodeSmall.val;

            if (takeNext)
            {
                sum++;
                takeNext = false;
            }

            if (sum > 9)
            {
                //if sum is over 10
                nodeSmall.val = sum % 10;
                finalResult.Push(new ListNode(nodeSmall.val));
                //take 1 digit to the next iteration
                takeNext = true;
            }
            else
            {
                nodeSmall.val = sum;
                finalResult.Push(new ListNode(nodeSmall.val));
            }
        }

        //if stackSmall is already exhausted
        while (stackBig.Count != 0)
        {
            var nodeBig = stackBig.Pop();
            nodeBig.next = null;

            if (takeNext)
            {
                nodeBig.val++;
                takeNext = false;
            }

            if (nodeBig.val > 9)
            {
                nodeBig.val %= 10;
                finalResult.Push(new ListNode(nodeBig.val));
                takeNext = true;
            }
            else
            {
                finalResult.Push(new ListNode(nodeBig.val));
            }
        }

        //if takeNext is true, add last digit 1
        if(takeNext) finalResult.Push(new ListNode(1));

        ListNode result = new ListNode();
        dummy1.next = result;
        while (finalResult.Count != 0)
        {
            var digit = finalResult.Pop();
            result.next = digit;
            result = result.next;
        }


        return dummy1.next.next;
    }
}