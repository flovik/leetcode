namespace Sandbox.Solutions.Medium;

public class RotateArray
{
    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;
        Array.Reverse(nums, 0, nums.Length - k);
        Array.Reverse(nums, nums.Length - k, k);
        Array.Reverse(nums);
    }
}