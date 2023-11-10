using System.Runtime.InteropServices;
using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class MergeTwoSortedLists
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var cur = new ListNode();
        var result = new ListNode(0, cur);

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                cur.next = list1;
                cur = cur.next;
                list1 = list1.next;
            }
            else
            {
                cur.next = list2;
                cur = cur.next;
                list2 = list2.next;
            }
        }

        // if any is exhausted
        while (list1 != null)
        {
            cur.next = list1;
            cur = cur.next;
            list1 = list1.next;
        }

        while (list2 != null)
        {
            cur.next = list2;
            cur = cur.next;
            list2 = list2.next;
        }

        return result.next.next;
    }
}