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

    public long MinCostBinarySearch(int[] nums, int[] cost)
    {
        // convex function like V graph, the topdown point is the lowest cost
        // BS in range
        var n = nums.Length;
        long result = long.MaxValue;

        long left = 1, right = 1;

        foreach (var num in nums)
        {
            left = Math.Min(num, left);
            right = Math.Max(num, right);
        }

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            var cost1 = GetCost(nums, cost, mid);
            var cost2 = GetCost(nums, cost, mid + 1);

            if (cost1 > cost2)
                left = mid + 1;
            else
                right = mid - 1;

            result = Math.Min(result, Math.Min(cost1, cost2));
        }

        return result;

        long GetCost(int[] nums, int[] cost, long num)
        {
            long result = 0;
            for (int i = 0; i < n; i++)
            {
                var val = Math.Abs(nums[i] - num);
                result += val * cost[i];
            }

            return result;
        }
    }
}