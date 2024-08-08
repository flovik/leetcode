namespace Sandbox.Solutions.Medium;

public class SubarraySumEqualsK
{
    public int SubarraySum(int[] nums, int k)
    {
        var map = new Dictionary<int, int>(nums.Length) { { 0, 1 } };
        var result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            // compute prefix sum of the array, it will give us the continuous sum of all the numbers until i
            if (i > 0)
                nums[i] += nums[i - 1];

            if (!map.ContainsKey(nums[i]))
                map.Add(nums[i], 1);
            else
                map[nums[i]]++; // we could have multiple sums with same key

            // by having that prefix, say we have a prefix =  5 and k = 3, so we need to find sum where it was 2
            // so we can remove all the numbers from that specific 2, so we will be left with numbers from right of 2
            if (map.ContainsKey(nums[i] - k))
                result += map[nums[i] - k];
        }

        // when k = 0, the whole nums array is appended to result
        if (k == 0)
            result -= nums.Length;

        return result;
    }
}