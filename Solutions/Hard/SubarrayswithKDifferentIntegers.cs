namespace Sandbox.Solutions.Hard;

public class SubarrayswithKDifferentIntegers
{
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        // number of different integers is exactly K
        var dict = new Dictionary<int, int>(nums.Length);
        // count -> stores the count of subarrays with the current distinct elements
        int left = 0, right = 0, result = 0, count = 0;

        while (right < nums.Length)
        {
            // extend window
            dict.TryAdd(nums[right], 0);

            if (dict[nums[right]] == 0)
                k--;

            dict[nums[right]]++;

            // shrink window, more than K distinct elements
            if (k < 0)
            {
                dict[nums[left]]--;
                left++;

                k++;
                count = 0;
            }

            if (k == 0)
            {
                // handle duplicates
                while (dict[nums[left]] > 1)
                {
                    dict[nums[left]]--;
                    count++;
                    left++;
                }

                result += count + 1;
            }

            right++;
        }

        return result;
    }
}