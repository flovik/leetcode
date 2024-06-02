namespace Sandbox.Solutions.Medium;

public class CheckifThereisaValidPartitionForTheArray
{
    public bool ValidPartition(int[] nums)
    {
        if (nums.Length == 1)
            return false;

        if (nums.Length == 2)
            return IsIdentical(nums[0], nums[1]);

        // dp[0] represents the validity of the partition from back to i+2
        // dp[1] represents the validity of the partition from back to i+1
        // dp[2] represents the validity of the partition from back to i
        var dp = new bool[3];
        dp[1] = IsIdentical(nums[^2], nums[^1]);
        dp[0] = IsIdentical(nums[^3], nums[^2], nums[^1]) ||
                 IsIncreasing(nums[^3], nums[^2], nums[^1]);

        for (int i = nums.Length - 4; i >= 0; i--)
        {
            var cur = false;

            if (IsIdentical(nums[i], nums[i + 1]))
                cur = cur || dp[1];
            if (IsIdentical(nums[i], nums[i + 1], nums[i + 2]))
                cur = cur || dp[2];
            if (IsIncreasing(nums[i], nums[i + 1], nums[i + 2]))
                cur = cur || dp[2];

            // move dp values by one
            dp[2] = dp[1];
            dp[1] = dp[0];
            dp[0] = cur;
        }

        return dp[0];
    }

    private bool IsIdentical(int x, int y) => x == y;

    private bool IsIdentical(int x, int y, int z) => x == y && x == z;

    private bool IsIncreasing(int x, int y, int z) => x == y - 1 && y == z - 1;

    /*
     *
     * 4 4 4 5 6
     * we only need an array of 3 values, because old ones aren't being needed
     * initialise last 3 three numbers
     * ... 6 -> false, can't partition
     * ... 5 6 -> false, not valid
     * ... 4 5 6 -> true, valid partition
     * i = 1, take 4 and next 4, they are identical, so check dp[i + 1], where is 5, it's false partition, so ignore
     * i = 1, take 4 4 5, not identical -> ignore
     * i = 1, take 4 4 5, not increasing -> ignore, but if increasing, take dp[i + 2]
     *
     * move dp values to the right by one
     * current dp = false, true, false
     * i = 0, take 4 and 4, dp[i + 1] = true, because 4 5 6, so stop here
     */
}