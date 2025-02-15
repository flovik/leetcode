namespace Sandbox.Solutions.Medium;

public class MinimumIncrementToMakeArrayUnique
{
    public int MinIncrementForUnique(int[] nums)
    {
        var result = 0;

        Array.Sort(nums);
        var maxSoFar = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= maxSoFar)
            {
                result += (maxSoFar + 1) - nums[i];
                nums[i] = maxSoFar + 1;
            }

            maxSoFar = nums[i];
        }

        return result;
    }
}