namespace Sandbox.Solutions.Hard;

public class BestTimetoBuyandSellStockIII
{
    public int MaxProfit(int[] prices)
    {
        var n = prices.Length;
        var dp = new int[3, n];
        var min = new int[3];

        Array.Fill(min, prices[0]);

        for (var i = 1; i < n; i++)
        {
            for (var j = 1; j <= 2; j++)
            {
                min[j] = Math.Min(min[j], prices[i] - dp[j - 1, i - 1]);

                // if we don't trade, take as prev day or sell the share on i-th day
                dp[j, i] = Math.Max(dp[j, i - 1], prices[i] - min[j]);
            }
        }

        return dp[2, n - 1];
    }
}