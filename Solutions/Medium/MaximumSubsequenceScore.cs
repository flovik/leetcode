namespace Sandbox.Solutions.Medium;

public class MaximumSubsequenceScore
{
    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int a, int b) => b.CompareTo(a);
    }

    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        var nums = new (int, int)[nums1.Length];
        for (var i = 0; i < nums1.Length; i++)
        {
            nums[i] = (nums1[i], nums2[i]);
        }

        // sort by multiplier
        Array.Sort(nums, (a, b) => b.Item2.CompareTo(a.Item2));

        long curSum = 0, result = 0;
        var minHeap = new PriorityQueue<int, int>(k); // min heap stores smallest sum numbers that must be discarded in case new better sums appear

        for (var i = 0; i < nums.Length; i++)
        {
            minHeap.Enqueue(nums[i].Item1, nums[i].Item1);
            curSum += nums[i].Item1;

            if (minHeap.Count > k)
            {
                curSum -= minHeap.Dequeue();
            }

            if (minHeap.Count == k)
            {
                // nums2 is guaranteed to be sorted in decreasing order
                result = Math.Max(result, curSum * nums[i].Item2);
            }
        }

        return result;
    }
}