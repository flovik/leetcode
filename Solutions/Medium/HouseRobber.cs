namespace Sandbox.Solutions.Medium;

public class HouseRobber
{
    public int Rob(int[] nums)
    {
        if (nums.Length >= 2)
            nums[1] = Math.Max(nums[1], nums[0]);

        for (int i = 2; i < nums.Length; i++)
        {
            nums[i] = Math.Max(nums[i - 1], nums[i] + nums[i - 2]);
        }

        return nums[^1];
    }
}