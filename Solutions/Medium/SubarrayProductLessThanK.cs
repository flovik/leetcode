using System.Reflection.Metadata.Ecma335;

namespace Sandbox.Solutions.Medium;

public class SubarrayProductLessThanK
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1)
            return 0;

        var result = 0;

        var currentProduct = 1;
        int left = 0, right = 0;

        while (right < nums.Length)
        {
            currentProduct *= nums[right];

            while (currentProduct >= k)
                currentProduct /= nums[left++];

            result += 1 + (right - left); // right - left - number of contiguous sub arrays within the current window
            right++;
        }

        return result;
    }
}