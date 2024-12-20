namespace Sandbox.Solutions.Hard;

public class CountAllValidPickupAndDeliveryOptions
{
    public int CountOrders(int n)
    {
        const int mod = 1_000_000_007;
        var dp = new long[n + 1];
        dp[1] = 1;

        // for current n (e.g 2), we'll have double the pickup * delivery positions (4)
        // for each position (1..4), we have a place to put P(i) between already existing pickups and deliveries
        // (x)P1(x)P2(x)D1(x)D2(x), I can place P3 to any (x) and D3 must be at the right
        // for current position in sequence, add how many remaining places to put D3 and move P3 to the right of (x)'s

        for (int i = 2; i <= n; i++)
        {
            dp[i] = 2 * (i * i) - i;
            dp[i] = dp[i] * dp[i - 1] % mod;
        }

        return (int)dp[n] % mod;
    }
}