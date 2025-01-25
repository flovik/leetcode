namespace Sandbox.Solutions.Medium;

public class MaximumAlternatingSubsequenceSum
{
    public long MaxAlternatingSum(int[] nums)
    {
        // dp[(i, flag)]
        // three states -> take current (with add or subtract) or ignore current
        var dp = new long[2][];
        dp[0] = new long[nums.Length];
        dp[1] = new long[nums.Length];

        // + first
        dp[0][0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            dp[0][i] = Math.Max(dp[0][i], dp[1][i - 1] + nums[i]);
            dp[0][i] = Math.Max(dp[0][i], dp[0][i - 1]);

            dp[1][i] = Math.Max(dp[1][i], dp[0][i - 1] - nums[i]);
            dp[1][i] = Math.Max(dp[1][i], dp[1][i - 1]);
        }

        return Math.Max(dp[1][^1], dp[0][^1]);
    }
}