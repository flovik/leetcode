namespace Sandbox.Solutions.Medium;

public class ChampagneTower
{
    public double ChampagneTowerSol(int poured, int query_row, int query_glass)
    {
        // poured - amount of cups poured on the first cup
        // rate of current cup is calculated by the rate of upper two cups
        // rate[i][j] = (rate[i - 1][j - 1] + rate[i - 1][j]) / 2

        // row n has n cups

        var dp = new double[101][];

        for (int i = 0; i < 101; i++)
        {
            dp[i] = new double[i + 1];
        }

        dp[0][0] = poured;

        for (int i = 0; i <= query_row; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (dp[i][j] > 1)
                {
                    dp[i + 1][j] = dp[i + 1][j] + (dp[i][j] - 1) / 2.0;
                    dp[i + 1][j + 1] = dp[i + 1][j + 1] + (dp[i][j] - 1) / 2.0;
                    dp[i][j] = 1;
                }
            }
        }

        if (dp[query_row][query_glass] > 1)
            dp[query_row][query_glass] = 1;

        return dp[query_row][query_glass];
    }
}