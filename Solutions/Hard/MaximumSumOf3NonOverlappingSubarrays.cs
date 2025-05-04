using System.Security.Cryptography;

namespace Sandbox.Solutions.Hard;

public class MaximumSumOf3NonOverlappingSubarrays
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        var dp = new int[nums.Length - k + 1];

        int left = 0, right = 0;
        var sum = 0;

        while (right < nums.Length)
        {
            sum += nums[right++];

            if (right < k) continue;

            dp[left] = sum;
            sum -= nums[left++];
        }

        // calculate the maximum prefix sums for sub arrays ending before each index
        // calculate the maximum suffix sums for sub arrays starting after each index

        var maxLeft = new int[dp.Length];
        var maxRight = new int[dp.Length];

        maxLeft[0] = 0;

        for (var i = 1; i < dp.Length; i++)
        {
            maxLeft[i] = dp[i] > dp[maxLeft[i - 1]] ? i : maxLeft[i - 1];
        }

        maxRight[^1] = dp.Length - 1;
        for (var i = dp.Length - 2; i >= 0; i--)
        {
            maxRight[i] = dp[i] >= dp[maxRight[i + 1]] ? i : maxRight[i + 1];
        }

        var ans = new int[3];
        var max = 0;

        // iterate through all middle values and find their best left and right prefix/suffix
        for (var i = k; i <= dp.Length - k - 1; i++)
        {
            var l = maxLeft[i - k];
            var r = maxRight[i + k];
            var total = dp[l] + dp[i] + dp[r];

            if (total <= max) continue;
            max = total;
            ans[0] = l;
            ans[1] = i;
            ans[2] = r;
        }

        return ans;
    }
}