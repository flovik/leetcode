using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class ReverseLinkedList
{
    private Stack<ListNode> listNodes = new Stack<ListNode>();
    public ListNode ReverseList(ListNode head)
    {
        var prev = new ListNode();
        while (head is not null)
        {
            listNodes.Push(head);
            head = head.next;
        }

        var node = new ListNode();
        prev.next = node;
        while (listNodes.Count != 0)
        {
            node.next = listNodes.Pop();
            node = node.next;
        }

        node.next = null;

        return prev.next.next;
    }
}