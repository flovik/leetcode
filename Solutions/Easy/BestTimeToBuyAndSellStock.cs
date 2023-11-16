namespace Sandbox.Solutions.Easy;

public class BestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        // sliding window
        var smallestPrice = prices[0];
        var profit = prices[0] - smallestPrice;

        for (int i = 1; i < prices.Length; i++)
        {
            // is the current price the smallest?
            if (prices[i] < smallestPrice)
                smallestPrice = prices[i];

            // is the current price bigger than our profit?
            if (prices[i] - smallestPrice > profit)
                profit = prices[i] - smallestPrice;
        }

        return profit > 0 ? profit : 0;
    }

    /*
     * 7,1,5,3,6,4
     *
     * like track two variables that will keep current profit on each iteration, we care about profit and not maximum ever met (especially in the past)
     * smallest: 7 1 1 (profit) 1 1 (new profit) 1
     *  biggest: 7 1 5 (profit) 5 6 (new profit) 6
     */
}