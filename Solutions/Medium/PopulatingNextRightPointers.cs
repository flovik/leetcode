using System.Collections;
using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class PopulatingNextRightPointers
{
    public NodeNext? Connect(NodeNext? root)
    {
        if (root is null) return root;
        Helper(root.left, root.right);
        return root;
    }

    private void Helper(NodeNext? node, NodeNext? next)
    {
        if (node is null) return;
        node.next = next;
        Helper(node.left, node.right);
        Helper(next.left, next.right);
        Helper(node.right, next.left);
    }
}