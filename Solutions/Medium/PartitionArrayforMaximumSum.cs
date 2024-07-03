namespace Sandbox.Solutions.Medium;

public class PartitionArrayforMaximumSum
{
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        // write down on paper the code and you'll understand
        var dp = new int[arr.Length + 1];

        for (var i = 1; i <= arr.Length; i++)
        {
            var max = arr[i - 1];
            for (var j = 1; j <= k; j++)
            {
                // handle out-of-bounds
                if (i < j)
                    break;

                // update the biggest value in subsequence if encountered
                max = Math.Max(max, arr[i - j]);

                // take previous subsequence + current subsequence with biggest value in subsequence
                dp[i] = Math.Max(dp[i], dp[i - j] + max * j);
            }
        }

        return dp[^1];
    }
}