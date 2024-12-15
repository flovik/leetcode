namespace Sandbox.Solutions.Medium;

public class New21Game
{
    public double New21GameSol(int n, int k, int maxPts)
    {
        // sliding window + dp
        // everything that is bigger than n is 0
        // everything from k to n is 1
        // take the sum from k to maxPts and divide to maxPts
        // slide the window once with new probability
        if (n >= k + maxPts)
            return 1.0;

        var dp = new double[maxPts + k + 1];

        for (int i = k; i <= n; i++)
        {
            dp[i] = 1;
        }

        double curSum = n - k + 1;
        var left = k - 1;
        var right = left + maxPts;

        while (left >= 0)
        {
            dp[left] = curSum / (maxPts * 1.0);
            curSum += dp[left--];
            curSum -= dp[right--];
        }

        return dp[0];
    }
}