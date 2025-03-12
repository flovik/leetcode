namespace Sandbox.Solutions.Hard;

internal class MaximumValueOfKCoinsFromPiles
{
    public int MaxValueOfCoins(IList<IList<int>> piles, int k)
    {
        // looks like coin change, think
        // imagine you have k = 3, you start with k = 1, that means you take one of the coins
        // then k = 2, it is either 1 + 1 or 2
        // then k = 3, it is either 1 + 1 + 1 or 2 + 1 or 3, you see the pattern? you can reuse the previously
        // computed 1 + 1 or 2 to get the best answer
        // coin change is one dimensional, that one is 2 dimensional with K
        var dp = new int[piles.Count][];

        for (int i = 0; i < piles.Count; i++)
        {
            dp[i] = new int[k + 1];
        }

        // compute prefix sum
        for (var p = 0; p < piles.Count; p++)
        {
            var pile = piles[p];

            for (var i = 1; i <= k; i++)
            {
                if (i < pile.Count)
                    dp[p][i] = pile[i];

                if (i > 0)
                    dp[p][i] += dp[p][i - 1];
            }
        }

        var result = 0;

        for (var i = 0; i < piles.Count; i++)
        {
            for (var coin = 1; coin <= k; coin++)
            {
            }
        }

        return result;
    }

    private int[][] _cache;

    public int MaxValueOfCoinsRecursive(IList<IList<int>> piles, int k)
    {
        _cache = new int[piles.Count][];

        for (int i = 0; i < piles.Count; i++)
        {
            _cache[i] = new int[k + 1];
            Array.Fill(_cache[i], -1);
        }

        return Backtrack(0, k);

        int Backtrack(int curPileIndex, int k)
        {
            // out-of-bounds
            if (curPileIndex == piles.Count)
                return 0;

            if (_cache[curPileIndex][k] != -1)
                return _cache[curPileIndex][k];

            // not take
            _cache[curPileIndex][k] = Backtrack(curPileIndex + 1, k);

            // take
            var pile = piles[curPileIndex];
            var curCoin = 0;

            for (var coin = 1; coin <= Math.Min(k, pile.Count); coin++)
            {
                curCoin += pile[coin - 1]; // += because I would take prefix of the pile

                // cur coin + next pile value
                var nextCoin = Backtrack(curPileIndex + 1, k - coin);

                _cache[curPileIndex][k] = Math.Max(_cache[curPileIndex][k], curCoin + nextCoin);
            }

            return _cache[curPileIndex][k];
        }
    }
}