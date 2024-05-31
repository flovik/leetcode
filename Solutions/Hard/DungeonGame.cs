namespace Sandbox.Solutions.Hard;

public class DungeonGame
{
    public int CalculateMinimumHP(int[][] dungeon)
    {
        // 2DP, bottom up
        // arrive to the recurrence relation and try to figure out how to optimize it
        var dp = new int[dungeon.Length + 1][];
        for (var i = 0; i < dungeon.Length + 1; i++)
        {
            dp[i] = new int[dungeon[0].Length + 1];
            Array.Fill(dp[i], int.MaxValue);
        }

        // starting hp is 1
        dp[dungeon.Length][dungeon[0].Length - 1] = 1;
        dp[dungeon.Length - 1][dungeon[0].Length] = 1;

        // go from bottom to top
        for (int i = dungeon.Length - 1; i >= 0; i--)
        {
            for (int j = dungeon[i].Length - 1; j >= 0; j--)
            {
                var current = Math.Min(dp[i + 1][j], dp[i][j + 1]) - dungeon[i][j];
                dp[i][j] = current >= 0 ? current : 1;
            }
        }

        return dp[0][0];
    }
}