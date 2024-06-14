namespace Sandbox.Topics.Queue;

// FIFO data structure
// queue is a kind-of representation of how a linked list works
// enqueue() -> add next tail
// dequeue() -> remove head, make the next node as the head
public class Queue<T> where T : class
{
    public int Length { get; private set; }
    private QueueNode<T> _head;
    private QueueNode<T> _tail;

    public Queue(T value)
    {
        _head = new QueueNode<T>(value);
        _tail = _head;
        Length = 0;
    }

    public void Enqueue(T item)
    {
        Length++;
        if (_tail is null)
        {
            _tail = _head = new QueueNode<T>(item);
        }

        var node = new QueueNode<T>(item);
        _tail.Next = node;
        _tail = node;
    }

    public T Dequeue()
    {
        if (_head is null)
            return null;

        Length--;

        var old = _head;

        _head = _head.Next;

        // free memory
        old.Next = null;

        return old.Value;
    }

    public T Peek()
    {
        return _head.Value;
    }
}

internal class QueueNode<T>
{
    public T Value { get; set; }
    public QueueNode<T> Next { get; set; }

    public QueueNode(T value)
    {
        Value = value;
    }
}