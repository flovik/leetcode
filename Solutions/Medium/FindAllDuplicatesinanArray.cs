namespace Sandbox.Solutions.Medium;

public class FindAllDuplicatesinanArray
{
    public IList<int> FindDuplicates(int[] nums)
    {
        // mark every num as negative
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] *= -1;
        }

        // if see negative, mark as positive counterpart
        // if see positive, mark as num + nums.Length
        // if is bigger than nums.Length (it is part of a result), but can contain further correct results

        for (int i = 0; i < nums.Length; i++)
        {
            var current = Math.Abs(nums[i]);

            if (current > nums.Length)
                current -= nums.Length;

            var target = nums[current - 1];

            if (target < 0)
                nums[current - 1] *= -1;
            else
            {
                if (target <= nums.Length)
                    target += nums.Length;

                nums[current - 1] = target;
            }
        }

        // move all numbers bigger than nums.Length to start of array and return it
        var index = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > nums.Length)
                nums[index++] = i + 1;
        }

        return nums[..index];
    }
}