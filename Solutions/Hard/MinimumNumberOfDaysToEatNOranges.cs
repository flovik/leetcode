namespace Sandbox.Solutions.Hard;

public class MinimumNumberOfDaysToEatNOranges
{
    private readonly Dictionary<int, int> _dp = new();

    public int MinDays(int n)
    {
        // draw decision tree and visualize the states and how they should go in DP array
        // how to get to eat-8, div-9, div-6 and how they repeat, start from day 1 and try to figure it out
        // instead of computing all the states, DFS to only needed ones

        if (n <= 1)
            return n;

        if (_dp.TryGetValue(n, out var days))
            return days;

        // n % 2 and n % 3 -> remaining of n / 2 and 2 * n / 3 operations
        var result = Math.Min(n % 2 + MinDays(n / 2), n % 3 + MinDays(n / 3)) + 1;
        _dp.TryAdd(n, result);
        return result;
    }

    public int MinDaysMle(int n)
    {
        // gives MLE! it calculates states that are not necessarily needed
        // draw decision tree and visualize the states and how they should go in DP array
        // how to get to eat-8, div-9, div-6 and how they repeat, start from day 1 and try to figure it out
        var dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            Math.DivRem(i, 2, out var divTwoRem);
            Math.DivRem(i, 3, out var divThreeRem);

            if (divTwoRem == 0)
                dp[i] = Math.Min(dp[i], dp[i - i / 2] + 1);

            if (divThreeRem == 0)
                dp[i] = Math.Min(dp[i], dp[i - 2 * (i / 3)] + 1);

            dp[i] = Math.Min(dp[i - 1] + 1, dp[i]);
        }

        return dp[n];
    }
}