namespace Sandbox.Solutions.Medium;

public class CountSquareSubmatricesWithAllOnes
{
    public int CountSquares(int[][] matrix)
    {
        var arr = new int[matrix.Length + 1][];

        for (int i = 0; i < matrix.Length + 1; i++)
        {
            arr[i] = new int[matrix[0].Length + 1];
        }

        for (var i = 0; i < matrix.Length; i++)
        {
            Array.Copy(matrix[i], 0, arr[i + 1], 1, matrix[i].Length);
        }

        var count = 0;
        for (var i = 1; i < arr.Length; i++)
        {
            for (var j = 1; j < arr[i].Length; j++)
            {
                if (arr[i][j] > 0)
                    arr[i][j] = Math.Min(arr[i][j - 1], Math.Min(arr[i - 1][j], arr[i - 1][j - 1])) + 1;

                count += arr[i][j];
            }
        }

        return count;
    }
}