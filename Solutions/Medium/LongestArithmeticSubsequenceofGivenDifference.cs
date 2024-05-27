namespace Sandbox.Solutions.Medium;

public class LongestArithmeticSubsequenceofGivenDifference
{
    public int LongestSubsequence(int[] arr, int difference)
    {
        var dp = new Dictionary<int, int>(arr.Length) { { arr[0], 1 } };
        var max = 1;

        for (var i = 1; i < arr.Length; i++)
        {
            var previousValue = arr[i] - difference;

            if (dp.ContainsKey(previousValue))
                dp[arr[i]] = dp[previousValue] + 1;
            else
                dp.TryAdd(arr[i], 1);

            max = Math.Max(max, dp[arr[i]]);
        }

        return max;
    }
}