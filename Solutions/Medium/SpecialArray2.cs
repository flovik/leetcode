namespace Sandbox.Solutions.Medium;

public class SpecialArray2
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        // dp holds the ranges of queries
        // it starts at 0 and if the next pair is NOT special, increment num
        // because the range finishes there
        // 4 3 1 6
        // 0 0 1 1
        // here is 0 0, because the range is still correct, but it changes to 1, because 3 and 1 have same parity
        var dp = new int[nums.Length];
        var res = new bool[queries.Length];

        for (int i = 1, j = 0; i < nums.Length; i++)
        {
            if (!IsSpecial(nums[i], nums[i - 1]))
                j++;

            dp[i] = j;
        }

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            res[i] = dp[query[0]] == dp[query[1]];
        }

        return res;
    }

    public bool IsSpecial(int x, int y) => x % 2 != y % 2;
}