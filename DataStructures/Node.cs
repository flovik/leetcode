namespace Sandbox.DataStructures;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val, Node _next = null, Node _random = null)
    {
        val = _val;
        next = _next;
        random = _random;
    }
}