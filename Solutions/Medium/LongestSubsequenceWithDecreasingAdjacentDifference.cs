namespace Sandbox.Solutions.Medium;

public class LongestSubsequenceWithDecreasingAdjacentDifference
{
    public int LongestSubsequence(int[] nums)
    {
        var n = nums.Length;
        var dp = new int[301][];
        var max = 0;

        for (int i = 0; i < 301; i++)
        {
            dp[i] = new int[301];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            var num = nums[i];
            for (var k = 1; k <= 300; k++)
            {
                var curDiff = Math.Abs(num - k);

                dp[num][curDiff] = Math.Max(dp[num][curDiff], dp[k][curDiff] + 1);
                max = Math.Max(max, dp[num][curDiff]);
            }

            for (var k = 1; k <= 300; k++)
            {
                dp[num][k] = Math.Max(dp[num][k], dp[num][k - 1]);
            }
        }

        return max;
    }
}