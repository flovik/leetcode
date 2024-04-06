namespace Sandbox.Solutions.Medium;

public class BestTimetoBuyandSellStockwithCooldown
{
    public int MaxProfit(int[] prices)
    {
        // naive
        var dp = new int[prices.Length];

        for (var i = prices.Length - 2; i >= 0; i--)
        {
            var maxProfit = 0;
            for (var j = prices.Length - 1; j > i; j--)
            {
                var cooldown = j + 2 < prices.Length ? dp[j + 2] : 0;

                dp[i] = Math.Max(prices[j] - prices[i] + cooldown, dp[j]);

                maxProfit = Math.Max(maxProfit, dp[i]);
            }

            dp[i] = maxProfit;
        }

        return dp[0];
    }

    public int MaxProfitOptimized(int[] prices)
    {
        // optimized
        if (prices.Length == 0 || prices.Length == 1)
            return 0;

        var dp = new int[prices.Length];
        dp[0] = 0;
        dp[1] = Math.Max(0, prices[1] - prices[0]);

        // cooldown = dp[j - 2] - prices[j]
        var cooldown = Math.Max(-prices[0], -prices[1]);
        for (var i = 2; i < prices.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], cooldown + prices[i]);
            cooldown = Math.Max(cooldown, dp[i - 2] - prices[i]);
        }

        return dp[prices.Length - 1];
    }
}