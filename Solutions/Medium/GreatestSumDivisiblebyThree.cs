namespace Sandbox.Solutions.Medium;

public class GreatestSumDivisiblebyThree
{
    public int MaxSumDivThree(int[] nums)
    {
        // dp[i][m] m - mod, largest sum from a subset of nums[:i] such that the sum % 3 equals m
        // nums[i] = 4, 4 % 3 = 1,
        // if we add a number with remainder 1 to a sum with remainder 1, we get a number with remainder 2
        // how to get dp[i][0] with remainder 1? add sum with remainder 2
        // dp[i][1] with remainder 1? dp[i - 1][0]
        var dp = new int[3][];

        for (int i = 0; i < 3; i++)
        {
            dp[i] = new int[nums.Length + 1];
        }

        dp[1][0] = int.MinValue;
        dp[2][0] = int.MinValue;

        for (int i = 1; i <= nums.Length; i++)
        {
            if (nums[i - 1] % 3 == 0)
            {
                dp[0][i] = Math.Max(dp[0][i - 1] + nums[i - 1], dp[0][i - 1]);
                dp[1][i] = Math.Max(dp[1][i - 1] + nums[i - 1], dp[1][i - 1]);
                dp[2][i] = Math.Max(dp[2][i - 1] + nums[i - 1], dp[2][i - 1]);
            }
            else if (nums[i - 1] % 3 == 1)
            {
                dp[0][i] = Math.Max(dp[2][i - 1] + nums[i - 1], dp[0][i - 1]);
                dp[1][i] = Math.Max(dp[0][i - 1] + nums[i - 1], dp[1][i - 1]);
                dp[2][i] = Math.Max(dp[1][i - 1] + nums[i - 1], dp[2][i - 1]);
            }
            else
            {
                dp[0][i] = Math.Max(dp[1][i - 1] + nums[i - 1], dp[0][i - 1]);
                dp[1][i] = Math.Max(dp[2][i - 1] + nums[i - 1], dp[1][i - 1]);
                dp[2][i] = Math.Max(dp[0][i - 1] + nums[i - 1], dp[2][i - 1]);
            }
        }

        return dp[0][^1];
    }
}