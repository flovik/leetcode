namespace Sandbox.Solutions.Medium;

public class FindDuplicateNumber
{
    public int FindDuplicate(int[] nums)
    {
        //we know the array consists of n + 1 integers in range of [1, n], so we can bounce
        //between indexes of the array and check if the current number bounces to itself
        //the duplicate is the entry point of the cycle
        //to find the entry, introduce fast and slow pointer, fast will go 2 steps, slow will 1 step, sometime they will meet

        int slow = nums[0];
        int fast = nums[nums[0]];
        
        //find meeting point
        while (true)
        {
            if (fast == slow) break;
            fast = nums[nums[fast]];
            slow = nums[slow];
        }

        //place slow at the start 
        //fast remains at the starting point
        //advance both one node each time
        slow = 0;
        while (true)
        {
            if (fast == slow) return fast; //the points where cycle starts
            slow = nums[slow];
            fast = nums[fast];
        }

        return 0;
    }
}