namespace Sandbox.Solutions.Medium;

public class PerfectSquaresSol
{
    public int NumSquares(int n)
    {
        var perfectSquareCount = (int) Math.Sqrt(n);
        var perfectSquareNumbers = new int[perfectSquareCount];

        // initialize perfect square numbers
        for (var i = 1; i <= perfectSquareCount; i++)
        {
            perfectSquareNumbers[i - 1] = (int) Math.Pow(i, 2);
        }

        var dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);

        dp[0] = 0;

        for (var i = 1; i <= n; i++)
        {
            foreach (var number in perfectSquareNumbers)
            {
                if (number > i)
                    continue;

                if (i % number == 0)
                    dp[i] = i / number;

                dp[i] = Math.Min(dp[i], dp[i - number] + 1);
            }
        }

        return dp[n];
    }
}