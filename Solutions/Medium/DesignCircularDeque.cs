using NUnit.Framework;

namespace Sandbox.Solutions.Medium;

public class MyCircularDeque
{
    private readonly LinkedList<int> _deque;
    private int Capacity;

    public MyCircularDeque(int k)
    {
        _deque = new LinkedList<int>();
        Capacity = k;
    }

    public bool InsertFront(int value)
    {
        if (IsFull())
            return false;

        _deque.AddFirst(value);

        return true;
    }

    public bool InsertLast(int value)
    {
        if (IsFull())
            return false;

        _deque.AddLast(value);

        return true;
    }

    public bool DeleteFront()
    {
        if (IsEmpty())
            return false;

        _deque.RemoveFirst();

        return true;
    }

    public bool DeleteLast()
    {
        if (IsEmpty())
            return false;

        _deque.RemoveLast();

        return true;
    }

    public int GetFront()
    {
        if (IsEmpty())
            return -1;

        return _deque.First.Value;
    }

    public int GetRear()
    {
        if (IsEmpty())
            return -1;

        return _deque.Last.Value;
    }

    public bool IsEmpty()
    {
        return _deque.Count == 0;
    }

    public bool IsFull()
    {
        return _deque.Count == Capacity;
    }
}