namespace Sandbox.Solutions.Medium;

public class IntegerBreak
{
    public int IntegerBreakSol(int n)
    {
        if (n is 2 or 3)
            return n - 1;

        if (n is 4)
            return n;

        // i - 2 or i - 3
        var dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 1;

        for (int i = 3; i <= n; i++)
        {
            dp[i] = Math.Max(dp[i - 2] * (i - (i - 2)), dp[i - 3] * (i - (i - 3)));
        }

        return dp[n];
    }
}