namespace Sandbox.Solutions.Easy;

public class KthLargestElementinaStream
{
    private readonly PriorityQueue<int, int> _minHeap = new();
    private readonly int _k;

    public KthLargestElementinaStream(int k, int[] nums)
    {
        foreach (var num in nums)
        {
            _minHeap.Enqueue(num, num);
        }

        _k = k;

        // drop lowest elements while k != q.Count
        while (k < _minHeap.Count)
        {
            _minHeap.Dequeue();
        }
    }

    public int Add(int val)
    {
        _minHeap.Enqueue(val, val);

        // drop smallest element
        if (_k < _minHeap.Count)
            _minHeap.Dequeue();

        return _minHeap.Peek();
    }
}