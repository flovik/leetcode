namespace Sandbox.Solutions.Hard;

public class ConstrainedSubsequenceSum
{
    public int ConstrainedSubsetSumBetter(int[] nums, int k)
    {
        // for every two integers, their indices diff must be in K range
        // dynamic programming gives TLE
        // use max heap

        var dp = new int[nums.Length];
        Array.Copy(nums, dp, nums.Length);
        var pq = new PriorityQueue<(int, int), int>(k, Comparer<int>.Create((a, b) => b.CompareTo(a)));

        for (var i = 0; i < nums.Length; i++)
        {
            var from = Math.Clamp(i - k, 0, i);

            // out-of-range item
            while (pq.Count > 0 && pq.Peek().Item2 < from)
                pq.Dequeue();

            // if top of heap is between K range, then it is the best answer for current
            if (pq.Count > 0)
                dp[i] = Math.Max(dp[i], pq.Peek().Item1 + nums[i]);

            pq.Enqueue((dp[i], i), dp[i]);
        }

        return dp.Max();
    }

    public int ConstrainedSubsetSum(int[] nums, int k)
    {
        // for every two integers, their indices diff must be in K range
        // dynamic programming
        // O (n * k) time, O (n) space
        // gives TLE

        var dp = new int[nums.Length];
        Array.Copy(nums, dp, nums.Length);

        for (var i = 0; i < nums.Length; i++)
        {
            var start = Math.Clamp(i - k, 0, i);
            for (var j = start; j < i; j++)
            {
                dp[i] = Math.Max(dp[i], dp[j] + nums[i]);
            }
        }

        return dp.Max();
    }
}