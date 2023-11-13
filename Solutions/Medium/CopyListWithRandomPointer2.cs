using Sandbox.DataStructures;
using System.Runtime.ConstrainedExecution;

namespace Sandbox.Solutions.Medium;

public class CopyListWithRandomPointer2
{
    private readonly IDictionary<int, Node> _hashCodeToNodes = new Dictionary<int, Node>();

    public Node CopyRandomList(Node head)
    {
        if (head == null)
            return null;

        var prevHead = new Node(0, head);

        // create a new list and save hash codes of the nodes in the dictionary
        // old hash codes will point to new nodes

        while (head != null)
        {
            var cur = new Node(head.val);
            _hashCodeToNodes.Add(head.GetHashCode(), cur);
            head = head.next;
        }

        // traverse old list, look for each random.GetHashCode() value and update to new node

        head = prevHead.next;
        var result = new Node(int.MinValue, _hashCodeToNodes[head.GetHashCode()]);

        while (head != null)
        {
            var nodeToUpdate = _hashCodeToNodes[head.GetHashCode()];

            if (head.next is not null)
                nodeToUpdate.next = _hashCodeToNodes[head.next.GetHashCode()];

            if (head.random is not null)
                nodeToUpdate.random = _hashCodeToNodes[head.random.GetHashCode()];

            head = head.next;
        }

        return result.next;
    }
}