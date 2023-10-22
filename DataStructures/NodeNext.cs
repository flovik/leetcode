namespace Sandbox.DataStructures;

public class NodeNext
{
    public int val;
    public NodeNext left;
    public NodeNext right;
    public NodeNext next;

    public NodeNext() { }

    public NodeNext(int _val)
    {
        val = _val;
    }

    public NodeNext(int _val, NodeNext _left = null, NodeNext _right = null, NodeNext _next = null)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}