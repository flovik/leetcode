namespace Sandbox.Solutions.Medium;

public class MaximumSumCircularSubarray
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        // kadane's algorithm
        // if you think about it, it is a sliding window

        // arr contains largest sums to ..i
        int maxSum = nums[0], curSum = 0, minSum = nums[0], minCurSum = 0, totalSum = 0;

        foreach (var num in nums)
        {
            curSum = Math.Max(curSum, 0) + num; // if a negative value, just ignore it
            maxSum = Math.Max(maxSum, curSum);

            // find min sum array
            minCurSum = Math.Min(minCurSum, 0) + num;
            minSum = Math.Min(minSum, minCurSum);

            // prefix sum
            totalSum += num;
        }

        // in case all numbers are negative
        if (totalSum == minSum)
            return maxSum;

        return Math.Max(maxSum, totalSum - minSum);
    }
}