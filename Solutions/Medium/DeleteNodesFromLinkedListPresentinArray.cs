using Sandbox.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class DeleteNodesFromLinkedListPresentinArray
{
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        var dict = new HashSet<int>(nums);

        var dummy = new ListNode();
        var cur = dummy;

        while (head != null)
        {
            if (!dict.Contains(head.val))
            {
                cur.next = head;
                cur = cur.next;
            }

            head = head.next;
        }

        cur.next = null;
        return dummy.next;
    }
}