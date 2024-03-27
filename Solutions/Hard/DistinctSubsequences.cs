namespace Sandbox.Solutions.Hard;

public class DistinctSubsequences
{
    public int NumDistinct(string s, string t)
    {
        // draw a 2D grid as in other DP problems and figure out the pattern
        var dp = new int[t.Length + 1, s.Length + 1];

        for (var i = 0; i <= s.Length; i++)
            dp[t.Length, i] = 1;

        for (var i = t.Length - 1; i >= 0; i--)
        {
            for (var j = s.Length - 1; j >= 0; j--)
            {
                if (s[j] == t[i])
                    dp[i, j] = dp[i + 1, j + 1] + dp[i, j + 1];
                else
                    dp[i, j] = dp[i, j + 1];
            }
        }

        return dp[0, 0];
    }
}