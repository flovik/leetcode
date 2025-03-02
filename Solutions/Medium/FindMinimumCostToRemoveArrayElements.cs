namespace Sandbox.Solutions.Medium;

internal class FindMinimumCostToRemoveArrayElements
{
    private int[][] _cache;

    public int MinCost(int[] nums)
    {
        _cache = new int[nums.Length + 1][];

        for (int i = 0; i < nums.Length + 1; i++)
        {
            _cache[i] = new int[nums.Length + 1];
            Array.Fill(_cache[i], -1);
        }

        return Backtrack(nums, 1, 0);

        int Backtrack(int[] arr, int i, int leftout)
        {
            if (arr.Length <= i + 1)
                return Math.Max(arr[leftout], i < arr.Length ? arr[i] : 0);

            // further when repeated calls will be made (e.g. dp[5][4], dp[5][3]) just take from cache the result
            if (_cache[i][leftout] != -1)
                return _cache[i][leftout];

            var second = arr[i]; // second
            var third = arr[i + 1]; // third
            var first = arr[leftout]; // first

            var value = Math.Max(second, third) + Backtrack(arr, i + 2, leftout);
            value = Math.Min(value, Math.Max(first, second) + Backtrack(arr, i + 2, i + 1));
            value = Math.Min(value, Math.Max(first, third) + Backtrack(arr, i + 2, i));

            return _cache[i][leftout] = value;
        }
    }
}