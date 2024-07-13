namespace Sandbox.Solutions.Medium;

public class OnesAndZeroes
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        var dp = new int[m + 1, n + 1];

        Array.Sort(strs, (str1, str2) => str1.Length - str2.Length);

        foreach (var str in strs)
        {
            var ones = str.Count(e => e == '1');
            var zeroes = str.Length - ones;

            for (var i = m; i >= zeroes; i--)
            {
                for (var j = n; j >= ones; j--)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - zeroes, j - ones] + 1);
                }
            }
        }

        return dp[m, n];
    }
}