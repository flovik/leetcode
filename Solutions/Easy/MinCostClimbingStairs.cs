namespace Sandbox.Solutions.Easy;

public class MinCostClimbingStairsSolution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var stairsSaved = new int[cost.Length + 1];

        stairsSaved[0] = cost[0];
        stairsSaved[1] = cost[1];

        for (int i = 2; i < cost.Length; i++)
        {
            stairsSaved[i] = cost[i] + Math.Min(stairsSaved[i - 1], stairsSaved[i - 2]);
        }

        stairsSaved[^1] = Math.Min(stairsSaved[^2], stairsSaved[^3]);

        return stairsSaved[^1];
    }
}