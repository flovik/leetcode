namespace Sandbox.Solutions.Medium;

public class DominoAndTrominoTiling
{
    public int NumTilings(int n)
    {
        if (n == 1)
            return 1;

        var dp = new long[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            dp[i] = (dp[i - 1] * 2 + dp[i - 3]) % 1_000_000_007;
        }

        return (int) dp[n];
    }
}