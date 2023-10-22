namespace Sandbox.Solutions.Medium;

public class MaximumProductSubarray
{
    public int MaxProduct(int[] nums)
    {
        nums = new[] { 3, -1, -5, 5, 3, -4, 10, 5 };
        int max = int.MinValue;
        int localMax = 1;
        // take all the left sides when ex odd numbers
        for (int i = 0; i < nums.Length; i++)
        {
            max = Math.Max(localMax *= nums[i], max);
            if (nums[i] == 0) localMax = 1; // resetting
        }

        localMax = 1;
        // take all the right sides of negative numbers
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            max = Math.Max(localMax *= nums[i], max);
            if (nums[i] == 0) localMax = 1;
        }

        return max;
    }

    /*
     *  negative numbers can be like pillars between sub arrays
     *  0 resets or divides the arrays into two halves
     *  if array has even number of negative numbers, forward traversal or reverse will result in the same outcome
     *  if multiple odd numbers, the max product is limited by the last negative integer in each traversal
     */
}