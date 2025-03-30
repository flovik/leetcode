namespace Sandbox.Solutions.Hard;

public class MinimumCostToDivideArrayIntoSubarrays
{
    public long MinimumCost(int[] nums, int[] cost, int k)
    {
        // i can divide in any number of sub arrays
        // [nums[left..right] + k * i], where i is the order of sub-array (first, second)
        // sub-array is contigous

        var prefixNums = new long[nums.Length];
        Array.Copy(nums, prefixNums, nums.Length);

        for (int i = 1; i < nums.Length; i++)
        {
            prefixNums[i] += prefixNums[i - 1];
        }

        var suffixCost = new long[nums.Length];
        Array.Copy(cost, suffixCost, nums.Length);

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffixCost[i] = suffixCost[i + 1] + cost[i];
        }

        // minimum cost to split array prefix starting at i
        var dp = new long[nums.Length];
        Array.Fill(dp, -1);

        var min = Backtrack(0);
        return min;

        long Backtrack(int left)
        {
            if (left == nums.Length)
                return 0;

            if (dp[left] != -1)
                return dp[left];

            // iterate thru all possible subarrays starting at left and compute cost
            // 1. compute subarray sum from nums[left..right] using prefixSum[right]
            // 2. compute subarray cost sum from cost[left..right] using suffixCost

            long cost = long.MaxValue;

            for (var right = left; right < nums.Length; right++)
            {
                var prefixCost = prefixNums[right];

                var totalSuffixCost = suffixCost[left];
                var redundantSuffixCost = right + 1 < nums.Length ? suffixCost[right + 1] : 0;

                var subArrayCost = totalSuffixCost - redundantSuffixCost;

                // ((sum of subarray) + k * (order of subarray)) * (sum of cost values in subarray)
                // if decompose that formula, we can get another formula
                // (sum of subarray) * (sum of cost values in subarray) + k * (order of subarray) * (sum of cost values in subarray)
                // why is (order of subarray) * (sum of cost values in subarray) = totalSuffixCost?
                // imagine nums = [A, B] and cost = [X, Y]
                // by splitting, you get [A] Cost1 = (A + K×1)×X, and second [B] Cost2 = (A + B + K×2)×Y
                // X + Y + Y, two Y's instead of 1, the additional Y is the extra penalty

                // [3,1,4] cost = [4, 6, 6], k = 1
                // when [3] = cost = (3 * 4) + 1 * 16 (4 + 6 + 6), we will still need to take the rest of 6 and 6,
                // but it will be done in [1,4] or [1], [4] decisions, that's the penalty that you take into account now, but not in
                // next subarrays computations
                var curCost = (prefixCost * subArrayCost) + k * totalSuffixCost;

                var nextSubArrayCost = Backtrack(right + 1);

                cost = Math.Min(cost, curCost + nextSubArrayCost);
            }

            return dp[left] = cost;
        }
    }
}