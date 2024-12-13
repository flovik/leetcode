namespace Sandbox.Solutions.Medium;

public class CountWaysToBuildGoodStrings
{
    public int CountGoodStrings(int low, int high, int zero, int one)
    {
        // draw decision tree and think a little
        // start "", append 0 - zero times or append 1 - one times
        // low - minimum length, high - max length

        // a good string is a valid binary strings
        const int mod = 1_000_000_007;

        var dp = new long[high + 1];
        dp[0] = 1;

        for (var i = 1; i <= high; i++)
        {
            if (i - zero >= 0)
                dp[i] += dp[i - zero] % mod;

            if (i - one >= 0)
                dp[i] += dp[i - one] % mod;
        }

        long sum = 0;
        while (low <= high)
        {
            sum += dp[low++] % mod;
        }

        return (int)(sum % mod);
    }
}