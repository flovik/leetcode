namespace Sandbox.Solutions.Medium;

public class CoinChange2
{
    public int Change(int amount, int[] coins)
    {
        Array.Sort(coins);

        // unbounded knapsack problem, means we can use infinite number of items
        // bottom-up, basically we have 3 on position of coin 2, it says how can we use coins 2 and 5 to get 3
        // and for 3 on position of coin 1, how can we use coins 1 2 and 5 to get 3
        var dp = new int[coins.Length][];

        // initialize 0 for each coin with one
        for (var i = 0; i < coins.Length; i++)
        {
            dp[i] = new int[amount + 1];
            dp[i][0] = 1;
        }

        // from bottom to up, search if we can compute

        for (var i = 1; i < dp[0].Length; i++)
        {
            for (var j = dp.Length - 1; j >= 0; j--)
            {
                var computedAmount = i - coins[j];
                if (computedAmount < 0)
                    continue;

                // add lower coin row, because we can construct the currentAmount with those coins too
                if (j < dp.Length - 1)
                    dp[j][i] += dp[j + 1][i];

                dp[j][i] += dp[j][computedAmount];
            }
        }

        return dp[0][amount];
    }

    public int ChangeDpOptimizedSpace(int amount, int[] coins)
    {
        // instead of 2D array, a 1D array can be re-used the same time
        Array.Sort(coins);

        var dp = new int[amount + 1];

        // initialize 0 for each coin with one
        dp[0] = 1;

        foreach (var coin in coins)
        {
            for (var i = 1; i < amount + 1; i++)
            {
                var currentAmount = i - coin;
                if (currentAmount < 0)
                    continue;

                dp[i] += dp[currentAmount];
            }
        }

        return dp[amount];
    }

    /*
     * move from bottom to coin to upper from lower amount to biggest
     * think of recursion, you can make the decision of coins by choosing different possibilities of them
     * how to get rid of duplicates? [1 2 5] for coin 1, you can use any coin, for coin 2 you use [2, 5], for 5 only [5] and so on
     * to optimize that, use 2D array, as in the same approach, compute how many you can compute with 5, 2 and 5, then 1 and 2 and 5
     * for current amount, compute currentAmount - currentCoin and find already computedAmount
     * also sum lower rows, as to use another coins
     *   0 1 2 3 4 5 6
     * 1 1 1 2 2 3 4 5
     * 2 1 0 1 0 1 1 1
     * 5 1 0 0 0 0 1 0
     */
}