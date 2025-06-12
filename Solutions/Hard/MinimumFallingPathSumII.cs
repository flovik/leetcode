using System.Net;

namespace Sandbox.Solutions.Hard;

public class MinimumFallingPathSumII
{
    public int MinFallingPathSum(int[][] grid)
    {
        var len = grid.Length;
        var dp = new int[len];

        Array.Copy(grid[0], dp, len);

        for (var i = 1; i < len; i++)
        {
            var cur = new int[len];

            // instead of searching for the whole previous array, just save two smallest numbers
            // it is guaranteed if current num is equal to the smallest column, just pick the second smallest
            var (leftSmallest, smallestColumn, rightSmallest) = FindTwoSmallest(dp);

            for (var j = 0; j < len; j++)
            {
                var smallNumber = j != smallestColumn ? leftSmallest : rightSmallest;
                cur[j] = grid[i][j] + smallNumber;
            }

            dp = cur;
        }

        return dp.Min();
    }

    private (int min1, int min1Idx, int min2) FindTwoSmallest(int[] arr)
    {
        int min1 = int.MaxValue, min2 = int.MaxValue;
        var min1Idx = -1;

        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min1)
            {
                min2 = min1;
                min1 = arr[i];
                min1Idx = i;
            }
            else if (arr[i] < min2)
            {
                min2 = arr[i];
            }
        }

        return (min1, min1Idx, min2);
    }
}