using System.Runtime.InteropServices;

namespace Sandbox.Solutions.Medium;

public class MinimizeTheMaximumDifferenceOfPairs
{
    public int MinimizeMax(int[] nums, int p)
    {
        Array.Sort(nums);
        int left = 0, right = nums[^1] - nums[0]; // max difference in the array

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            // get the threshold
            if (CountValidPair(mid, nums) >= p)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private int CountValidPair(int threshold, int[] nums)
    {
        // count number of threshold in the array
        // threshold - range from lower to higher between pairs
        // if we get 3 pairs when the answer should be 2, the threshold is too large and we can narrow down it!
        var count = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i + 1] - nums[i] > threshold)
                continue;

            count++;
            i++;
        }

        return count;
    }
}