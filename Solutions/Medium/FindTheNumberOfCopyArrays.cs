using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

internal class FindTheNumberOfCopyArrays
{
    public int CountArrays(int[] original, int[][] bounds)
    {
        var n = original.Length;
        for (int i = 1; i < n; i++)
        {
            var diff = original[i] - original[i - 1];

            var prevBound = bounds[i - 1];
            var bound = bounds[i];

            var left = Math.Max(prevBound[0] + diff, bound[0]);
            var right = Math.Min(prevBound[1] + diff, bound[1]);
            bounds[i] = [left, right];
        }

        var val = bounds[^1][1] - bounds[^1][0] + 1;
        return val > 0 ? val : 0;
    }
}