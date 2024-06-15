namespace Sandbox.Solutions.Medium;

public class MyLinkedList
{
    private MyNode _head;
    private MyNode _tail;

    public MyLinkedList()
    {
        _head = new MyNode(0);
        _tail = new MyNode(0);
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public int Get(int index)
    {
        var curr = _head.Next;

        while (curr != _tail && index > 0)
        {
            curr = curr.Next;
            index--;
        }

        if (curr != _tail && index == 0)
            return curr.Value;

        return -1;
    }

    public void AddAtHead(int val)
    {
        var newHead = new MyNode(val);

        _head.Next.Prev = newHead;
        newHead.Next = _head.Next;
        newHead.Prev = _head;
        _head.Next = newHead;
    }

    public void AddAtTail(int val)
    {
        var newTail = new MyNode(val);

        _tail.Prev.Next = newTail;
        newTail.Next = _tail;
        newTail.Prev = _tail.Prev;
        _tail.Prev = newTail;
    }

    public void AddAtIndex(int index, int val)
    {
        var cur = _head.Next;

        while (cur != _tail && index > 0)
        {
            cur = cur.Next;
            index--;
        }

        if (index == 0)
        {
            var newMyNode = new MyNode(val);
            newMyNode.Next = cur;
            newMyNode.Prev = cur.Prev;
            cur.Prev.Next = newMyNode;
            cur.Prev = newMyNode;
        }
    }

    public void DeleteAtIndex(int index)
    {
        var cur = _head.Next;

        while (cur != _tail && index > 0)
        {
            cur = cur.Next;
            index--;
        }

        if (cur != _tail && index == 0)
        {
            cur.Prev.Next = cur.Next;
            cur.Next.Prev = cur.Prev;
        }
    }
}

public class MyNode(int value)
{
    public int Value { get; set; } = value;
    public MyNode Next { get; set; }
    public MyNode Prev { get; set; }
}