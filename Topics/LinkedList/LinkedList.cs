namespace Sandbox.Topics.LinkedList;

// complexity
// find - O(n)
// delete - O(1)
// insert - O(1)
// linked lists are good for basic of other data structures, to represent graphs as an example

public class LinkedList<T>
{
    private Node<T> _head;

    public LinkedList(T value)
    {
        _head = new Node<T>(value);
    }

    public void AddFirst(T value)
    {
        var temp = _head;
        var newNode = new Node<T>(value);

        newNode.Next = temp;
        temp.Prev = newNode;
        _head = newNode;
    }

    public void AddLast(T value)
    {
        var temp = _head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = new Node<T>(value);
    }

    public Node<T> FindFirst(T value)
    {
        var temp = _head;
        while (temp.Next != null && !temp.Next.Value.Equals(value))
            temp = temp.Next;

        return temp;
    }
}

// doubly linked list node
public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Prev { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}