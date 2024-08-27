namespace Sandbox.Solutions.Medium;

public class TwoCityScheduling
{
    public int TwoCitySchedCost(int[][] costs)
    {
        // compute differences of each cost, sort by highest difference to lowest
        Array.Sort(costs, (a, b) => Math.Abs(b[0] - b[1]).CompareTo(Math.Abs(a[0] - a[1])));

        var result = 0;
        var aCount = costs.Length / 2;
        var bCount = aCount;

        foreach (var cost in costs)
        {
            if (aCount == 0)
            {
                result += cost[1];
            }
            else if (bCount == 0)
            {
                result += cost[0];
            }
            else
            {
                if (cost[0] < cost[1])
                {
                    aCount--;
                    result += cost[0];
                }
                else
                {
                    bCount--;
                    result += cost[1];
                }
            }
        }

        return result;
    }
}