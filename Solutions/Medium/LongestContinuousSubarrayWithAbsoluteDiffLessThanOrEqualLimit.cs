namespace Sandbox.Solutions.Medium;

public class LongestContinuousSubarrayWithAbsoluteDiffLessThanOrEqualLimit
{
    public int LongestSubarray(int[] nums, int limit)
    {
        int n = nums.Length, left = 0, right = 0, answer = 0;
        var maxHeap = new PriorityQueue<(int value, int index), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        var minHeap = new PriorityQueue<(int value, int index), int>();

        while (right < n)
        {
            maxHeap.Enqueue((nums[right], right), nums[right]);
            minHeap.Enqueue((nums[right], right), nums[right]);

            while (maxHeap.Peek().value - minHeap.Peek().value > limit)
            {
                left++;

                while (maxHeap.TryPeek(out var top, out _) && top.index < left)
                    maxHeap.Dequeue();

                while (minHeap.TryPeek(out var top, out _) && top.index < left)
                    minHeap.Dequeue();
            }

            answer = Math.Max(answer, right - left + 1);
            right++;
        }

        return answer;
    }

    public int LongestSubarrayDequeue(int[] nums, int limit)
    {
        int left = 0, right = 0, answer = 0;
        var maxDeque = new LinkedList<int>();
        var minDeque = new LinkedList<int>();

        while (right < nums.Length)
        {
            while (maxDeque.Count > 0 && nums[right] > maxDeque.Last()) maxDeque.RemoveLast();
            while (minDeque.Count > 0 && nums[right] < minDeque.Last()) minDeque.RemoveLast();

            maxDeque.AddLast(nums[right]);
            minDeque.AddLast(nums[right]);

            if (maxDeque.First() - minDeque.First() > limit)
            {
                if (maxDeque.First() == nums[left]) maxDeque.RemoveFirst();
                if (minDeque.First() == nums[left]) minDeque.RemoveFirst();
                left++;
            }

            answer = Math.Max(answer, right - left + 1);
            right++;
        }

        return answer;
    }
}