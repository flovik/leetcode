using System.Runtime.Intrinsics.Arm;

namespace Sandbox.Solutions.Medium;

public class IncreasingTripletSubsequence
{
    public bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3)
            return false;

        // binary search solution O(nlogk), where k = 3, O(nlog3) => O(n)
        var sequenceIndex = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (sequenceIndex > 1)
                return true;

            // extend sequence
            if (nums[i] > nums[sequenceIndex])
            {
                sequenceIndex++;
                nums[sequenceIndex] = nums[i];
            }
            // replace
            else
            {
                var replace = Array.BinarySearch(nums, 0, sequenceIndex + 1, nums[i]);

                if (replace < 0)
                    replace = ~replace;

                nums[replace] = nums[i];
            }
        }

        return sequenceIndex > 1;
    }
}