namespace Sandbox.Solutions.Medium;

public class SumOfAbsoluteDifferencesInASortedArray
{
    public int[] GetSumAbsoluteDifferences(int[] nums)
    {
        // (value * i - prefix[i - 1]) + (suffix[i + 1] - value * (n - i - 1))
        // value * i = value is repeated i times and remove the prefix
        // value * (n - i - 1) = suffix of the value after current i
        var n = nums.Length;
        var prefix = new int[n];
        var suffix = new int[n];
        var result = new int[n];

        Array.Copy(nums, prefix, n);
        Array.Copy(nums, suffix, n);

        for (int i = 1; i < n; i++)
        {
            prefix[i] += prefix[i - 1];
        }

        for (int i = n - 2; i >= 0; i--)
        {
            suffix[i] += suffix[i + 1];
        }

        for (int i = 0; i < n; i++)
        {
            var value = nums[i];
            var pref = i > 0 ? prefix[i - 1] : 0;
            var suf = i < n - 1 ? suffix[i + 1] : 0;

            var res = (value * i - pref) + (suf - value * (n - i - 1));
            result[i] = res;
        }

        return result;
    }
}