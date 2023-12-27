using Sandbox.Solutions.Medium;

namespace Sandbox.Solutions.Hard;

public class MedianFinder
{
    // stores larger half
    private readonly PriorityQueue<int, int> _minHeap = new();

    // stores smaller half
    private readonly PriorityQueue<int, int> _maxHeap = new(new MaxHeapComparer());

    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    public MedianFinder()
    {
        // middle value in an ordered integer list
        // if even => two middle values
        // two heaps, one min heap, one max heap
    }

    public void AddNum(int num)
    {
        // we can have even number of elements in both heaps (small, large) = (k, k)
        // or odd (small, large) = (k, k + 1)

        // enqueue in max heap
        // always contains the smaller half of the numbers
        _maxHeap.Enqueue(num, num);

        // enqueue top element of max heap into min heap
        // move largest element in the smaller half to the min heap, which is the largest half
        _minHeap.Enqueue(_maxHeap.Peek(), _maxHeap.Dequeue());

        // balance heaps (max heap no more elements than min heap)
        if (_maxHeap.Count < _minHeap.Count)
            _maxHeap.Enqueue(_minHeap.Peek(), _minHeap.Dequeue());
    }

    public double FindMedian()
    {
        // returns the median of all elements so far.
        // median - sorted data and middle element. sorted means 'collection' + manual sort of SBT or multituple heaps
        // or monotonic stack or Deque (not that helpful, because they involve removal)
        // heap - help to get smallest/biggest element fast
        // 2 heaps - divide random data into 2 heaps (1 min 1 max), first half of sorted data is in max heap and second half of sorted data is in min heap
        // easily get middle element of sorted data
        if (_maxHeap.Count == _minHeap.Count)
            return (_minHeap.Peek() + _maxHeap.Peek()) / 2.0;

        return _maxHeap.Peek();
    }
}