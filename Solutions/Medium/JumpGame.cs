using System;

namespace Sandbox.Solutions.Medium;

public class JumpGame
{
    public bool CanJump(int[] nums)
    {
        var localMax = nums[0];
        for (var i = 0; i < nums.Length - 1; i++)
        {
            localMax = Math.Max(--localMax, nums[i]);

            if (localMax <= 0)
                return false;
        }

        return true;
    }
}