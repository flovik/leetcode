namespace Sandbox.Solutions.Medium;

public class LongestIncreasingSubsequenceSolution
{
    public int LengthOfLIS(int[] nums)
    {
        // in the naive solution, we go right to left and for each number we calculate all the numbers strictly decreasing from them
        // and to make things better, we will use dynamic programming to memorize the numbers from the left to right and for the current
        // we will put the previous number + 1
        var result = 1;
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[j] < nums[i] && dp[j] >= dp[i])
                {
                    dp[i] = dp[j] + 1;
                    result = Math.Max(dp[i], result);
                }
            }
        }

        return result;
    }
}