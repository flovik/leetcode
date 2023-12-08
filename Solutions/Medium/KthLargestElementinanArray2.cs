namespace Sandbox.Solutions.Medium;

public class KthLargestElementinanArray2
{
    private readonly PriorityQueue<int, int> _maxHeap = new(new MaxHeapComparer());

    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    public int FindKthLargest(int[] nums, int k)
    {
        foreach (var num in nums)
        {
            _maxHeap.Enqueue(num, num);
        }

        while (k > 1)
        {
            _maxHeap.Dequeue();
            k--;
        }

        return _maxHeap.Peek();
    }
}