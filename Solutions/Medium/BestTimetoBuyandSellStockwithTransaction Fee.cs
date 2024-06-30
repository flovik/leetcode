namespace Sandbox.Solutions.Medium;

public class BestTimetoBuyandSellStockwithTransaction_Fee
{
    public int MaxProfit(int[] prices, int fee)
    {
        if (prices.Length == 1)
            return 0;

        var buy = new int[prices.Length]; // max profit at day i in buy status, given last action you took is a buy action at day K
        var sell = new int[prices.Length]; // max profit at day iin sell status, given last action you took is a sell action at day K

        buy[0] = -prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            buy[i] = Math.Max(buy[i - 1], sell[i - 1] - prices[i]); // buy or do nothing
            sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i] - fee); // sell or do nothing
        }

        return sell[^1];
    }
}