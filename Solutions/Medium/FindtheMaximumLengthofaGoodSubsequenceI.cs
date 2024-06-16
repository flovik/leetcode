namespace Sandbox.Solutions.Medium;

public class FindtheMaximumLengthofaGoodSubsequenceI
{
    public int MaximumLength(int[] nums, int k)
    {
        // longest good subsequence with K different neighbors
        var dp = new int[k + 1][];

        for (var i = 0; i <= k; i++)
        {
            dp[i] = new int[nums.Length];
        }

        // longest subsequence with K different neighbors
        var result = new int[k + 1];

        foreach (var num in nums)
        {
            for (var j = k; j >= 0; j--)
            {
                var v = dp[j][num];
                var availableNeighbor = j > 0 ? result[j - 1] + 1 : 0;

                v = Math.Max(v + 1, availableNeighbor);
                dp[j][num] = v;
                result[j] = Math.Max(result[j], v);
            }
        }

        return result[k];
    }
}