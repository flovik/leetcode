namespace Sandbox.Solutions.Medium;

public class BinarySubarraysWithSum
{
    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        // sliding window
        // each combination of prefix zeroes contributes to the total count of subarrays
        int count = 0, prefixZeroes = 0, left = 0, right = 0, curSum = 0;

        while (right < nums.Length)
        {
            curSum += nums[right];
            while (left < right && (nums[left] == 0 || curSum > goal))
            {
                if (nums[left] == 1)
                    prefixZeroes = 0;
                else
                    prefixZeroes++;

                curSum -= nums[left++];
            }

            if (curSum == goal)
                count += 1 + prefixZeroes;

            right++;
        }

        return count;
    }
}