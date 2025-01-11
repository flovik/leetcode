using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

internal class GridGame
{
    public long GridGameSol(int[][] grid)
    {
        var len = grid[0].Length;
        var prefixSum = new long[2][];
        for (int i = 0; i < 2; i++)
        {
            prefixSum[i] = new long[len];
            Array.Copy(grid[i], prefixSum[i], len);
        }

        for (int i = 1; i < len; i++)
        {
            prefixSum[0][i] += prefixSum[0][i - 1];
            prefixSum[1][i] += prefixSum[1][i - 1];
        }

        long min = long.MaxValue;
        for (int i = 0; i < len; i++)
        {
            var bottomSum = i > 0 ? prefixSum[1][i - 1] : 0;
            var upperSum = i < len - 1 ? prefixSum[0][^1] - prefixSum[0][i] : 0;

            var curMin = Math.Max(bottomSum, upperSum);
            min = Math.Min(min, curMin);
        }

        return min;
    }
}