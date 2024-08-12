namespace Sandbox.Solutions.Medium;

public class NonDecreasingArray
{
    public bool CheckPossibility(int[] nums)
    {
        var diff = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] - nums[i - 1] >= 0)
                continue;

            if (diff == 1)
                return false;

            // change current
            if (i > 1 && nums[i - 2] > nums[i])
                nums[i] = nums[i - 1];

            diff++;
        }

        return true;
    }
}