namespace Sandbox.Solutions.Medium;

public class MinimumFallingPathSum
{
    public int MinFallingPathSum(int[][] matrix)
    {
        // min sum of any falling path

        for (var i = 1; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                var cur = matrix[i][j];

                if (j == 0)
                    matrix[i][j] = Math.Min(matrix[i - 1][j] + cur, matrix[i - 1][j + 1] + cur);
                else if (j == matrix[i].Length - 1)
                    matrix[i][j] = Math.Min(matrix[i - 1][j] + cur, matrix[i - 1][j - 1] + cur);
                else
                {
                    matrix[i][j] = Math.Min(
                        Math.Min(matrix[i - 1][j] + cur, matrix[i - 1][j + 1] + cur),
                        matrix[i - 1][j - 1] + cur);
                }
            }
        }

        return matrix[^1].Min();
    }
}