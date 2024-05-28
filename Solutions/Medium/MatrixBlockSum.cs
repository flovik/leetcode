namespace Sandbox.Solutions.Medium;

public class MatrixBlockSum
{
    public int[][] MatrixBlockSumSol(int[][] mat, int k)
    {
        var columnsDp = new int[mat.Length][];

        for (var i = 0; i < mat.Length; i++)
        {
            columnsDp[i] = new int[mat[i].Length];

            for (var j = 0; j < mat[i].Length; j++)
            {
                columnsDp[i][j] = mat[i][j];
            }
        }

        // calculate prefix sum of matrix based on column
        for (var i = 1; i < columnsDp.Length; i++)
        {
            for (var j = 0; j < columnsDp[i].Length; j++)
            {
                columnsDp[i][j] += columnsDp[i - 1][j];
            }
        }

        for (var i = 0; i < mat.Length; i++)
        {
            for (var j = 0; j < mat[i].Length; j++)
            {
                var fromY = Math.Clamp(i - k, 0, mat.Length - 1);
                var toY = Math.Clamp(i + k, 0, mat.Length - 1);
                var fromX = Math.Clamp(j - k, 0, mat[0].Length - 1);
                var toX = Math.Clamp(j + k, 0, mat[0].Length - 1);

                var sum = 0;
                while (fromX <= toX)
                {
                    sum += columnsDp[toY][fromX];

                    // remove sums that are out of bounds of current number
                    if (fromY > 0)
                        sum -= columnsDp[fromY - 1][fromX];

                    fromX++;
                }

                mat[i][j] = sum;
            }
        }

        return mat;
    }
}