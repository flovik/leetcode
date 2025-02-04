namespace Sandbox.Solutions.Medium;

public class NumberOfDiceRollsWithTargetSum
{
    public int NumRollsToTarget(int n, int k, int target)
    {
        const int MOD = 1_000_000_007;

        var dp = new int[n + 1][];

        for (int i = 0; i < n + 1; i++)
        {
            dp[i] = new int[target + 1];
        }

        for (int face = 1; face <= k && face <= target; face++)
        {
            dp[1][face] = 1;
        }

        for (int dice = 2; dice <= n; dice++)
        {
            for (int sum = 1; sum <= target; sum++)
            {
                dp[dice][sum] = 0;

                // take the sum of all combinations of the previous dice of can be made with cur face
                for (int face = 1; face <= k; face++)
                {
                    if (sum - face <= 0)
                        break;

                    dp[dice][sum] = (dp[dice][sum] + dp[dice - 1][sum - face]) % MOD;
                }
            }
        }

        return dp[n][target];
    }
}