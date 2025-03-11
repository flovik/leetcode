namespace Sandbox.Solutions.Hard;

public class NumberOfWaysToRearrangeSticksWithKSticksVisible
{
    private const int mod = 1_000_000_007;

    public int RearrangeSticks(int n, int k)
    {
        var dp = new long[n + 1][];

        for (int i = 0; i <= n; i++)
        {
            dp[i] = new long[k + 1];
        }

        dp[0][0] = 1; // base case

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                long prevValues = (i - 1) * dp[i - 1][j] % mod;
                long curValue = dp[i - 1][j - 1] + prevValues % mod;
                dp[i][j] = curValue;
            }
        }

        return (int)(dp[n][k] % mod);
    }

    /*
     * // if n or k == 0, then 0
        // if n == k, then 1, because there is only one way to arrange them in such a way to have to have a valid answer
        // [1, 2], n = 2, k = 2, => 1

     * imagine you have the [1, 2, 3] arr, n = 3, k = 2,
     * you put the number at the end and try to figure the current n and k
     * if you pick 1, you have [2, 3], and 1 is not visible => n = 2, k = 2
     * if you pick 2, you have [1, 3], and 2 is not visible => n = 2, k = 2
     * if you pick 3, you have [1, 2], and 3 is visible => n = 2, k = 1
     * repeat that process for each n
     * dp[n][k] = dp[n - 1][k - 1] + (n - 1) * dp[n - 1][k];
     * (n - 1) * dp[n - 1][k] => means other branches where was picked not the greatest stick
     *
     * [2, 3]
     * if you pick 2, you have [3], and [2, 1] are not visible => n = 1, k = 2
     * if you pick 3, you have [2], and [3, 1], only 1 is not visible => n = 1, k = 1
     *
     * dp[0][0] ->
     * dp[1][1] -> means 1 is the last one to choose, [3, 2] were chosen already, and we can choose one available stick, because greater sticks
     * were already chosen
     * this is dp[1][1] = dp[0][0] + (n - 1) dp[0][1]; which is simply 1
     * but consider dp[2][2], that is dp[1][1] (which is 1) + 1 * dp[1][2];
     */
}