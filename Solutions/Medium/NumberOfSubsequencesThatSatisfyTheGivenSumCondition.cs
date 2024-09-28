using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class NumberOfSubsequencesThatSatisfyTheGivenSumCondition
{
    public int NumSubseq(int[] nums, int target)
    {
        // for each left, find out max right that satisfies condition
        // 2 ^ (j - i)

        Array.Sort(nums);
        int sum = 0;
        int left = 0, right = nums.Length - 1;

        // Calculate powers of 2 modulo mod
        var pow2 = new int[nums.Length];
        pow2[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            pow2[i] = (pow2[i - 1] * 2) % 1_000_000_007;
        }

        while (left <= right)
        {
            if (nums[left] + nums[right] > target)
                right--;
            else
            {
                sum = (sum + pow2[right - left]) % 1_000_000_007;
                left++;
            }
        }

        return sum;
    }
}