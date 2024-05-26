namespace Sandbox.Solutions.Medium;

public class LongestArithmeticSubsequence
{
    public int LongestArithSeqLength(int[] nums)
    {
        var dp = new Dictionary<int, int>[nums.Length];

        // initialize
        for (var i = 0; i < nums.Length; i++)
        {
            dp[i] = new Dictionary<int, int>(i + 1);
        }

        var max = 2;

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                var difference = nums[i] - nums[j];
                var previousDifference = dp[j].GetValueOrDefault(difference, 1);

                // avoid overriding the existing value
                if (dp[i].ContainsKey(difference) && dp[i][difference] < previousDifference + 1)
                    dp[i][difference] = previousDifference + 1;

                if (!dp[i].ContainsKey(difference))
                    dp[i].Add(difference, previousDifference + 1);

                max = Math.Max(max, dp[i][difference]);
            }
        }

        return max;
    }
}