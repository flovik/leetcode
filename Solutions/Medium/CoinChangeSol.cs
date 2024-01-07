namespace Sandbox.Solutions.Medium;

public class CoinChangeSol
{
    public int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount + 1];
        Array.Fill(dp, int.MaxValue);
        Array.Sort(coins);

        dp[0] = 0;

        // compute previous amounts to get the latest amount
        for (int i = 1; i <= amount; i++)
        {
            foreach (var coin in coins)
            {
                // no reason to check bigger coins a smaller amount
                if (coin > i)
                    break;

                // if the computed value is maxValue (nonexistent) then skip it
                if (dp[i - coin] == int.MaxValue)
                    continue;

                // biggest coin for current amount - dp[coin - i]
                // or previous with first

                var currentAmount = 1 + dp[i - coin];

                dp[i] = Math.Min(currentAmount, dp[i]);
            }
        }

        return dp[^1] == int.MaxValue ? -1 : dp[^1];
    }
}