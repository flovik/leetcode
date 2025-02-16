namespace Sandbox.Solutions.Hard;

public class MinimumCostToMakeArrayEqual
{
    public long MinCost(int[] nums, int[] cost)
    {
        var n = nums.Length;
        long result = 0;
        var numsCost = new (int, long)[n];

        for (int i = 0; i < n; i++)
        {
            numsCost[i] = (nums[i], cost[i]);
        }

        // transform cost to median array
        // you have [1, 2, 3, 5] and [2, 14, 3, 1], that means you have [1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2...]
        // you should take the median of that array and get the result

        Array.Sort(numsCost, (a, b) => a.Item1.CompareTo(b.Item1));
        long freq = numsCost.Sum((a) => a.Item2);

        long median = 0, total = 0;

        // find median
        for (int i = 0; i < n && total < (freq + 1) / 2; i++)
        {
            total += numsCost[i].Item2;
            median = numsCost[i].Item1;
        }

        for (int i = 0; i < n; i++)
        {
            var val = Math.Abs(numsCost[i].Item1 - median);
            result += val * numsCost[i].Item2;
        }

        return result;
    }
}