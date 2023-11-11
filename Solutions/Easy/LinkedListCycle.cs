using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class LinkedListCycle
{
    public bool HasCycle(ListNode head)
    {
        // slow/fast pointers are used to determine cycles
        var fast = head;
        var slow = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }

        return false;
    }
}