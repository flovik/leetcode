namespace Sandbox.Solutions.Medium;

public class ContinuousSubArraySum
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        nums[0] %= k;
        var map = new Dictionary<int, int>(nums.Length) { { nums[0], 0 } };

        // make prefix sum with % k
        // if found duplicated sum%k values, then the sub array between indexes will be the solution
        for (var i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i - 1];
            nums[i] %= k;

            if (nums[i] == 0)
                return true;

            if (map.TryGetValue(nums[i], out var value))
            {
                if (i - value >= 2)
                    return true;
            }
            else
                map.Add(nums[i], i);
        }

        return false;
    }

    public bool CheckSubarraySumTLE(int[] nums, int k)
    {
        // TLE
        var prefix = new int[nums.Length + 1];
        Array.Copy(nums, 0, prefix, 1, nums.Length); // first one will be 0 in case the whole row of nums is good

        for (var i = 1; i < prefix.Length; i++)
        {
            prefix[i] += prefix[i - 1];
        }

        for (var i = 0; i < prefix.Length; i++)
        {
            for (var j = i - 1; j >= 0; j--)
            {
                if ((prefix[j] - prefix[i]) % k == 0 && i - j >= 2)
                    return true;
            }
        }

        return false;
    }
}