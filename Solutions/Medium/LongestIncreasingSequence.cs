namespace Sandbox.Solutions.Medium;

public class LongestIncreasingSubsequenceSolution
{
    public int LengthOfLIS(int[] nums)
    {
        // in the naive solution, we go right to left and for each number we calculate all the numbers strictly decreasing from them
        // and to make things better, we will use dynamic programming to memorize the numbers from the left to right and for the current
        // we will put the previous number + 1
        var result = 1;
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[j] < nums[i] && dp[j] >= dp[i])
                {
                    dp[i] = dp[j] + 1;
                    result = Math.Max(dp[i], result);
                }
            }
        }

        return result;
    }

    public int LengthOfLIS_BinarySearch(int[] nums)
    {
        // O(n log n) time, O(1) space
        // update current array
        var endOfSequence = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            // extend the array
            if (nums[i] > nums[endOfSequence])
                nums[++endOfSequence] = nums[i];
            else
            {
                // replace old values with new applying binary search to find the place to replace
                var index = BinarySearch(nums[..(endOfSequence + 1)], nums[i]);
                nums[index] = nums[i];
            }
        }

        return endOfSequence + 1;
    }

    private int BinarySearch(int[] array, int value)
    {
        int start = 0, end = array.Length - 1;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;

            if (array[mid] == value)
                return mid;
            if (array[mid] < value)
                start = mid + 1;
            else
                end = mid - 1;
        }

        return end;
    }
}