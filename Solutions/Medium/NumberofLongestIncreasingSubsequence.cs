namespace Sandbox.Solutions.Medium;

public class NumberofLongestIncreasingSubsequence
{
    public int FindNumberOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        var longestCount = new int[nums.Length];
        Array.Fill(dp, 1);
        Array.Fill(longestCount, 1);

        var max = 1;

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    if (dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;

                        // if j-th paths were 2, so out current i will also have 2 paths
                        longestCount[i] = longestCount[j];
                    }
                    // subsequence of same length
                    else if (dp[j] + 1 == dp[i])
                    {
                        longestCount[i] += longestCount[j];
                    }
                }
            }

            max = Math.Max(max, dp[i]);
        }

        var result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (dp[i] == max)
                result += longestCount[i];
        }

        return result;
    }
}