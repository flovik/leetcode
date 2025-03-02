using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Easy;

internal class TransformArrayByParity
{
    public int[] TransformArray(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
                nums[i] = 0;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 1)
                nums[i] = 1;
        }

        Array.Sort(nums);
        return nums;
    }
}