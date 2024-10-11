namespace Sandbox.Solutions.Medium;

public class FrequencyOfTheMostFrequentElement
{
    public int MaxFrequency(int[] nums, int k)
    {
        Array.Sort(nums);
        int left = 0, right = 0, max = 0;
        long sum = 0;

        // sliding window + prefix sum
        while (right < nums.Length)
        {
            var rangeFrequency = (long) nums[right] * (right - left);

            if (rangeFrequency - sum > k)
            {
                sum -= nums[left];
                left++;
            }
            else
            {
                sum += nums[right];
                max = Math.Max(max, right - left + 1);
                right++;
            }
        }

        return max;
    }
}