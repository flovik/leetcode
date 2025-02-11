namespace Sandbox.Solutions.Medium;

public class FindPolygonWithTheLargestPerimeter
{
    public long LargestPerimeter(int[] nums)
    {
        // longest side is smaller than the sum of its other sides
        Array.Sort(nums);

        var prefix = new long[nums.Length];
        Array.Copy(nums, prefix, nums.Length);

        for (int i = 1; i < prefix.Length; i++)
        {
            prefix[i] += prefix[i - 1];
        }

        // for each side from bigger to smaller, find any sum that is the highest for the current side
        for (int i = nums.Length - 1; i >= 1; i--)
        {
            var side = nums[i];

            if (prefix[i - 1] > side)
                return prefix[i - 1] + side;
        }

        return -1;
    }
}