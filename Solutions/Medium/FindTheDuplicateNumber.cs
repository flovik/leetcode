namespace Sandbox.Solutions.Medium;

public class FindTheDuplicateNumber
{
    public int FindDuplicate(int[] nums)
    {
        // the duplicate is the entry point of the cycle
        // fast and slow pointer (as in linked list to find cycles)
        int fast = 0, slow = 0;

        // find the meeting point
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        // fast stays at the meeting point
        // because they are at the same distance between each other
        slow = 0;
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}