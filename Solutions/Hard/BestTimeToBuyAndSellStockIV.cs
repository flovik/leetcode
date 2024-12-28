namespace Sandbox.Solutions.Hard;

public class BestTimeToBuyAndSellStockIV
{
    public int MaxProfit(int k, int[] prices)
    {
        var transactions = new int[k + 1][]; // first transactions[0] is just dummy for zeroTransactions
        var min = new int[k + 1]; // saves min for each transaction

        for (var i = 0; i < k + 1; i++)
        {
            transactions[i] = new int[prices.Length];
        }

        for (var transaction = 1; transaction <= k; transaction++)
        {
            min[transaction] = prices[0];

            for (var j = 1; j < prices.Length; j++)
            {
                min[transaction] = Math.Min(min[transaction], prices[j] - transactions[transaction - 1][j - 1]);
                var profit = prices[j] - min[transaction];
                var prevProfit = transactions[transaction][j - 1];

                transactions[transaction][j] = Math.Max(transactions[transaction][j], Math.Max(prevProfit, profit));
            }
        }

        return transactions[k][^1];
    }
}