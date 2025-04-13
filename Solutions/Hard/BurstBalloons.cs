namespace Sandbox.Solutions.Hard;

public class BurstBalloons
{
    private int[][] _cache;

    public int MaxCoins(int[] nums)
    {
        // think of it as if you are popping the current number last, that means the remaining sub-array
        // is already computed

        var arr = new int[nums.Length + 2];

        Array.Copy(nums, 0, arr, 1, nums.Length);
        arr[0] = 1; arr[^1] = 1;

        _cache = new int[nums.Length + 2][];

        for (int i = 0; i < nums.Length + 2; i++)
        {
            _cache[i] = new int[nums.Length + 2];
            Array.Fill(_cache[i], -1);
        }

        return Backtrack(arr, 1, nums.Length);
    }

    private int Backtrack(int[] nums, int start, int end)
    {
        if (start > end)
            return 0;

        if (start == end)
            return nums[start - 1] * nums[start] * nums[start + 1];

        if (_cache[start][end] != -1)
            return _cache[start][end];

        var answer = 0;
        for (int k = start; k <= end; k++)
        {
            var take = nums[start - 1] * nums[k] * nums[end + 1];

            var left = Backtrack(nums, start, k - 1);
            var right = Backtrack(nums, k + 1, end);

            answer = Math.Max(answer, take + left + right);
        }

        return _cache[start][end] = answer;
    }
}