namespace Sandbox.Solutions.Medium;

internal class MinimizeMaximumofArray
{
    public int MinimizeArrayValue(int[] nums)
    {
        long curSum = nums[0];
        long result = nums[0];

        // prefix sum average, evenly distribute all the elements
        for (int i = 1; i < nums.Length; i++)
        {
            curSum += nums[i];
            result = Math.Max(result, (long) Math.Ceiling((double) curSum / (i + 1)));
        }

        return (int) result;
    }
}