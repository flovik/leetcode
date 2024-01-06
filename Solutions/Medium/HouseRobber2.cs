namespace Sandbox.Solutions.Medium;

public class HouseRobber2
{
    public int Rob(int[] nums)
    {
        // the same as the first house robber, but consider the last and first houses (in a circle)
        // nums will be used for the sub array [0]-[n - 1] and a second array [1] - [n]
        if (nums.Length == 1)
            return nums[0];

        if (nums.Length == 2)
            return Math.Max(nums[0], nums[1]);

        var secondHalf = new int[nums.Length - 1];

        Array.Copy(nums[1..], secondHalf, nums.Length - 1);

        nums[1] = Math.Max(nums[0], nums[1]);
        secondHalf[1] = Math.Max(secondHalf[0], secondHalf[1]);

        // don't consider last number of nums
        for (var i = 2; i < nums.Length - 1; i++)
        {
            nums[i] = Math.Max(nums[i] + nums[i - 2], nums[i - 1]);
        }

        for (var i = 2; i < secondHalf.Length; i++)
        {
            secondHalf[i] = Math.Max(secondHalf[i] + secondHalf[i - 2], secondHalf[i - 1]);
        }

        // compare which part of houses is better to rob
        return Math.Max(nums[^2], secondHalf[^1]);
    }
}