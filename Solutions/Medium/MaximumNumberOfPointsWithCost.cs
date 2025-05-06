namespace Sandbox.Solutions.Medium;

public class MaximumNumberOfPointsWithCost
{
    public long MaxPoints(int[][] points)
    {
        // pick one cell in each row
        // subtract column difference between rows
        var cols = points[0].Length;
        var rows = points.Length;

        var prevRow = new long[cols];

        for (var i = 0; i < cols; i++)
        {
            prevRow[i] = points[0][i];
        }

        var leftMax = new long[cols];
        var rightMax = new long[cols];
        var curRow = new long[cols];

        for (var row = 0; row < rows - 1; row++)
        {
            // instead of iterating over every number in previous array, use leftMax and RightMax to store
            // maximum possible contributions from the left and right

            leftMax[0] = prevRow[0];

            // compute the best possible left value that might come from the left side
            for (var col = 1; col < cols; col++)
            {
                leftMax[col] = Math.Max(leftMax[col - 1] - 1, prevRow[col]);
            }

            rightMax[cols - 1] = prevRow[cols - 1];

            for (var col = cols - 2; col >= 0; col--)
            {
                rightMax[col] = Math.Max(rightMax[col + 1] - 1, prevRow[col]);
            }

            for (var col = 0; col < cols; col++)
            {
                curRow[col] = Math.Max(leftMax[col], rightMax[col]) + points[row + 1][col];
            }

            prevRow = curRow;
        }

        return prevRow.Max();
    }
}