using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

internal class NumberOfZero_FilledSubarrays
{
    public long ZeroFilledSubarray(int[] nums)
    {
        // [2] -> 3, [3] -> 6, [4] -> 10, [5] -> 15, etc
        // prev value + cur key
        var occurences = new long[nums.Length + 1];
        for (int i = 1; i < nums.Length + 1; i++)
        {
            occurences[i] = occurences[i - 1] + i;
        }

        long result = 0;
        var zeros = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                zeros++;
            else
            {
                if (zeros > 0)
                    result += occurences[zeros];

                zeros = 0;
            }
        }

        if (zeros > 0)
            result += occurences[zeros];

        return result;
    }
}