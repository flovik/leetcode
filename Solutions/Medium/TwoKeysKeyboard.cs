namespace Sandbox.Solutions.Medium;

public class TwoKeysKeyboard
{
    public int MinSteps(int n)
    {
        var dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        dp[1] = 0;

        for (var i = 2; i <= n; i++)
        {
            for (var j = 1; j < i; j++)
            {
                if (i % j != 0)
                    continue;

                dp[i] = Math.Min(dp[i], dp[j] + i / j);
            }
        }

        return dp[^1];
    }
}