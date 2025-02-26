namespace Sandbox.Solutions.Medium;

public class LengthOfLongestSubarrayWithAtMostKFrequency
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>(nums.Length);

        // for each distinct num in nums add K bound
        foreach (var num in nums)
        {
            dict.TryAdd(num, k);
        }

        // window
        int left = 0, right = 0, result = 0;
        while (right < nums.Length)
        {
            var num = nums[right];

            dict[num]--;

            while (dict[num] < 0)
            {
                var leftNum = nums[left];
                dict[leftNum]++;
                left++;
            }

            result = Math.Max(result, right - left + 1);
            right++;
        }

        return result;
    }
}