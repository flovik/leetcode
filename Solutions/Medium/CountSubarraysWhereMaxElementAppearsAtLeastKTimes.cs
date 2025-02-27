namespace Sandbox.Solutions.Medium;

public class CountSubarraysWhereMaxElementAppearsAtLeastKTimes
{
    public long CountSubarrays(int[] nums, int k)
    {
        long result = 0;
        int max = nums.Max(), left = 0, right = 0, curK = 0;

        while (right < nums.Length)
        {
            if (nums[right] == max)
                curK++;

            while (curK == k)
            {
                var value = nums.Length - right;
                result += value;

                if (nums[left] == max)
                    curK--;

                left++;
            }

            right++;
        }

        return result;
    }
}