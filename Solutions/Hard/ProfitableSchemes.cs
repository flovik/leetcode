namespace Sandbox.Solutions.Hard;

public class ProfitableSchemes
{
    private const int mod = 1_000_000_007;
    private long[][][] _cache;

    public int ProfitableSchemesSol(int n, int minProfit, int[] group, int[] profit)
    {
        // number of schemes that can be generated
        // we either take group or skip it

        var sum = profit.Sum();

        _cache = new long[n + 1][][];

        for (var i = 0; i <= n; i++)
        {
            _cache[i] = new long[sum + 1][];

            for (var j = 0; j <= sum; j++)
            {
                _cache[i][j] = new long[group.Length + 1];
                Array.Fill(_cache[i][j], -1);
            }
        }

        return (int)(Backtrack(n, 0, 0) % mod);

        long Backtrack(int n, int income, int index)
        {
            // base case
            // used too many people
            if (n < 0)
                return 0;

            if (index == group.Length)
            {
                if (income < minProfit)
                    return 0;

                return 1;
            }

            if (_cache[n][income][index] != -1)
                return _cache[n][income][index];

            var notTake = Backtrack(n, income, index + 1);
            var take = Backtrack(n - group[index], income + profit[index], index + 1);

            return _cache[n][income][index] = (notTake + take) % mod;
        }
    }
}