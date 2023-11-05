namespace Sandbox.Solutions.Medium;

public class SearchA2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        // binary search leftmost and rightmost columns to get the needed row
        // then binary search the row

        if (matrix.Length == 1)
            return Array.BinarySearch(matrix[0], 0, matrix[0].Length, target) >= 0;

        int rightmostUp = 0,
            rightmostDown = matrix.Length - 1;

        while (rightmostUp <= rightmostDown)
        {
            var mid = rightmostUp + (rightmostDown - rightmostUp) / 2;

            if (matrix[mid][^1] < target)
                rightmostUp = mid + 1;
            else
                rightmostDown = mid - 1;
        }

        // if rightmostUp is bigger than len of array, then result is false
        if (rightmostUp > matrix.Length - 1)
            return false;

        // binary search row
        return Array.BinarySearch(matrix[rightmostUp], 0, matrix[rightmostUp].Length, target) >= 0;
    }
}