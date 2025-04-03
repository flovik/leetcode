namespace Sandbox.Solutions.Medium;

public class MaximumValueOfAnOrderedTriplet_II
{
    public long MaximumTripletValue(int[] nums)
    {
        long answer = 0;

        var prefix = new int[nums.Length];
        prefix[0] = nums[0];

        var suffix = new int[nums.Length];
        suffix[^1] = nums[^1];

        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = Math.Max(prefix[i - 1], nums[i]);
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffix[i] = Math.Max(suffix[i + 1], nums[i]);
        }

        for (int i = 1; i < nums.Length - 1; i++)
        {
            var ans = (long)(prefix[i - 1] - nums[i]) * suffix[i + 1];
            answer = Math.Max(answer, ans);
        }

        return answer;
    }
}