namespace Sandbox.Solutions.Medium;

public class DivideArrayIntoArraysWithMaxDifference
{
    public int[][] DivideArray(int[] nums, int k)
    {
        Array.Sort(nums);

        var list = new List<int[]>();

        for (int i = 0; i < nums.Length; i += 3)
        {
            var arr = new int[3];
            arr[0] = nums[i];
            arr[1] = nums[i + 1];
            arr[2] = nums[i + 2];

            if (arr[2] - arr[1] > k || arr[2] - arr[0] > k || arr[1] - arr[0] > k)
                return [];

            list.Add(arr);
        }

        return [.. list];
    }
}