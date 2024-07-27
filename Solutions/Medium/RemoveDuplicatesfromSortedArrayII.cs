namespace Sandbox.Solutions.Medium;

public class RemoveDuplicatesfromSortedArrayII
{
    public int RemoveDuplicates(int[] nums)
    {
        int left = 0, right = 0, currentNum = nums[0], count = 0;

        while (right < nums.Length)
        {
            if (nums[right] == currentNum)
            {
                if (count < 2)
                {
                    nums[left++] = currentNum;
                    count++;
                }
            }
            else
            {
                currentNum = nums[right];
                nums[left++] = currentNum;
                count = 1;
            }

            right++;
        }

        return left;
    }
}