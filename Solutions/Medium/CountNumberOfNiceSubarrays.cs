namespace Sandbox.Solutions.Medium;

public class CountNumberOfNiceSubarrays
{
    public int NumberOfSubarrays(int[] nums, int k)
    {
        // k odd numbers on it
        // replace even with 0 and odd with one and prefix sum it
        var arr = new int[nums.Length];
        var count = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 1)
                arr[i] = 1;
        }

        // slide window
        int left = 0, right = 0, curSum = 0, prefixZeroes = 0;

        while (right < arr.Length)
        {
            curSum += arr[right];

            while (left < right && (arr[left] == 0 || curSum > k))
            {
                if (arr[left] == 1)
                    prefixZeroes = 0;
                else
                    prefixZeroes++;

                curSum -= arr[left];
                left++;
            }

            if (curSum == k)
                count += 1 + prefixZeroes;

            right++;
        }

        return count;
    }
}