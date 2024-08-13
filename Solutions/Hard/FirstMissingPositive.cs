namespace Sandbox.Solutions.Hard;

public class FirstMissingPositive
{
    public int FirstMissingPositiveSol(int[] nums)
    {
        // O(n) time O(1) space
        // smallest positive integer that is not present in nums
        // think of the array as a hash map
        // mark 'present' with int.Minvalue in the nums

        // mark every number as positive
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > nums.Length || nums[i] <= 0)
                nums[i] = nums.Length + 1;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var num = Math.Abs(nums[i]);
            if (num > nums.Length)
                continue;

            num--;

            if (nums[num] > 0) // prevents double negative operations
                nums[num] = -1 * nums[num];
        }

        // think of the array as 1-indexed, first non negative number is the next positive
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= 0)
                return i + 1;
        }

        // the whole array has been traversed, like [1, 2, 0], so just take the next number, which is len of array
        return nums.Length + 1;
    }
}