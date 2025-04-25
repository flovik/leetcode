namespace Sandbox.Solutions.Medium;

public class MaximumSumOfDistinctSubarraysWithLengthK
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        long max = 0;
        var set = new Dictionary<int, int>(k);

        int left = 0, right = 0;
        long sum = 0;

        while (right < nums.Length)
        {
            set.TryAdd(nums[right], 0);
            set[nums[right]]++;

            sum += nums[right];

            if (right - left + 1 == k)
            {
                if (set.Count == k)
                    max = Math.Max(max, sum);

                if (set[nums[left]] > 1)
                    set[nums[left]]--;
                else
                    set.Remove(nums[left]);

                sum -= nums[left];
                left++;
            }

            right++;
        }

        return max;
    }
}