using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class ReorderList
{
    private readonly Stack<ListNode> _stack = new();

    // O(N) time O(N) space, two pointers and stack
    public void ReorderListSolution(ListNode head)
    {
        var slow = head;
        var fast = head;

        // slow and fast pointer to get to the middle of the list
        while (fast != null && fast.next != null)
        {
            slow = slow?.next;
            fast = fast?.next?.next;
        }

        //  and add the remaining slow pointer nodes in a stack
        while (slow != null)
        {
            _stack.Push(slow);
            slow = slow.next;
        }

        // apply reordering
        var prev = head;
        while (_stack.Count != 0)
        {
            // if prev is the same node on top of stack
            if (_stack.Count == 1 && prev.val == _stack.Peek().val)
                break;

            var next = prev.next;
            var dequeuedNode = _stack.Pop();
            prev.next = dequeuedNode;
            dequeuedNode.next = next;
            prev = next;
        }

        prev.next = null;
    }

    // O (N) time O(1) space by reversing the second half
    public void ReorderListSolution2(ListNode head)
    {
        var slow = head;
        var fast = head;

        // slow and fast pointer to get to the middle of the list
        while (fast != null && fast.next != null)
        {
            slow = slow?.next;
            fast = fast?.next?.next;
        }

        var next = slow.next;
        slow.next = null;
        // reverse second half of the list
        while (next != null)
        {
            var right = next?.next;
            next.next = slow;
            slow = next;
            next = right;
        }

        // now we have two detached lists (1, 2) and (4, 3), now merge them
        while (head.next != null && slow.next != null)
        {
            var headNext = head.next;
            var slowNext = slow.next;

            head.next = slow;
            slow.next = headNext;

            head = headNext;
            slow = slowNext;
        }
    }
}