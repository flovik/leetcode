namespace Sandbox.Solutions.Medium;

public class NumberOfWaysToSplitArray
{
    public int WaysToSplitArray(int[] nums)
    {
        var prefix = new int[nums.Length];
        Array.Copy(nums, prefix, nums.Length);

        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] += prefix[i - 1];
        }

        var result = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            var diff = prefix[i] - prefix[^1];
            if (prefix[i] > diff)
                result++;
        }

        return result;
    }
}