using System.Reflection;
using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class CopyListWithRandomPointer
{
    //https://leetcode.com/problems/copy-list-with-random-pointer/

    private readonly IDictionary<int, Node> NodeLocations = new Dictionary<int, Node>();
    private readonly IDictionary<Node, int> NodeIndexes = new Dictionary<Node, int>();
    private readonly IDictionary<int, Node> FinalNodeLocations = new Dictionary<int, Node>();

    public Node CopyRandomList(Node head)
    {
        //here we have a linked list, iterate the linked list until next is null, add for each index the reference to Node in memory
        var dummy = new Node(0)
        {
            next = head
        };

        //iterate list
        int index = 1;
        while (dummy.next is not null)
        {
            NodeLocations.Add(index, dummy.next);
            //add reference of a node and its index in list
            NodeIndexes[dummy.next] = index;
            index++;
            dummy.next = dummy.next.next;
        }

        //create new nodes
        for (int dictionaryIndex = 1; dictionaryIndex < index; dictionaryIndex++)
        {
            FinalNodeLocations.Add(dictionaryIndex, new Node(NodeLocations[dictionaryIndex].val));
        }

        //set references
        for (int dictionaryIndex = 1; dictionaryIndex < index; dictionaryIndex++)
        {
            if (NodeLocations[dictionaryIndex].next is not null)
            {
                var nodeIndex = NodeIndexes[NodeLocations[dictionaryIndex].next];
                FinalNodeLocations[dictionaryIndex].next = FinalNodeLocations[nodeIndex];
            }
            if (NodeLocations[dictionaryIndex].random is not null)
            {
                var nodeIndex = NodeIndexes[NodeLocations[dictionaryIndex].random];
                FinalNodeLocations[dictionaryIndex].random = FinalNodeLocations[nodeIndex];
            }
        }

        return FinalNodeLocations[1];
    }
}