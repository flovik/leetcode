namespace Sandbox.Solutions.Hard;

public class SlidingWindowMedian
{
    private class MaxHeapComparer : IComparer<long>
    {
        public int Compare(long a, long b) => b.CompareTo(a);
    }

    private PriorityQueue<long, long> minHeap;
    private PriorityQueue<long, long> maxHeap;

    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        var ans = new List<double>(nums.Length - k + 1);
        minHeap = new PriorityQueue<long, long>(nums.Length);
        maxHeap = new PriorityQueue<long, long>(nums.Length, new MaxHeapComparer());

        var left = 0;
        var right = 0;

        while (right < k)
        {
            AddNum(nums[right++]);
        }

        ans.Add(FindMedian());

        while (right < nums.Length)
        {
            minHeap.Clear();
            maxHeap.Clear();

            left++;
            right++;

            var n = nums[left..right];
            foreach (var i in n)
            {
                AddNum(i);
            }

            ans.Add(FindMedian());
        }

        return ans.ToArray();
    }

    private double FindMedian()
    {
        if (maxHeap.Count == minHeap.Count)
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;

        return maxHeap.Peek();
    }

    private void AddNum(int num)
    {
        maxHeap.Enqueue(num, num);
        minHeap.Enqueue(maxHeap.Peek(), maxHeap.Dequeue());

        if (maxHeap.Count < minHeap.Count)
            maxHeap.Enqueue(minHeap.Peek(), minHeap.Dequeue());
    }
}