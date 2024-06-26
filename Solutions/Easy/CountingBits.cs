namespace Sandbox.Solutions.Easy;

public class CountingBits
{
    public int[] CountBits(int n)
    {
        if (n == 0)
            return new[] { 0 };

        // get length of current bit range (powers of two)
        // use previous values to calculate current number of bits
        // at each range, add 1 to each number and mod current range length
        // 5 equals 1 + dp[5 - 4], where 4 is current range length
        var dp = new int[n + 1];
        dp[1] = 1;
        var currentBitRange = 2;
        var counterRange = currentBitRange;

        for (var i = 2; i <= n; i++)
        {
            dp[i] = 1 + dp[i % currentBitRange];
            counterRange--;

            if (counterRange >= 0)
                continue;

            currentBitRange *= 2;
            counterRange = currentBitRange;
        }

        return dp;
    }
}