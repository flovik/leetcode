namespace Sandbox.Solutions.Medium;

public class BestTimeToBuyAndSellStock2
{
    public int MaxProfit(int[] prices)
    {
        // you can sell and buy immediately on the same day
        // buy low - sell high
        var maxProfit = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
                maxProfit += prices[i] - prices[i - 1];
        }

        return maxProfit;
    }
}