namespace Sandbox.Solutions.Medium;

public class MaximumSquare
{
    public int MaximalSquare(char[][] matrix)
    {
        var max = 0;

        // see if we have any 1s
        foreach (var t in matrix)
        {
            if (t.Any(c => c == '1'))
                max = 1;
        }

        for (var i = 1; i < matrix.Length; i++)
        {
            for (var j = 1; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] != '0' && matrix[i - 1][j] != '0' &&
                    matrix[i - 1][j - 1] != '0' && matrix[i][j - 1] != '0')
                {
                    // take min of the 2x2 square of 3 values, and down right square will be that value and +1 that value
                    var value = Math.Min(Math.Min(matrix[i - 1][j - 1] - '0', matrix[i][j - 1] - '0'),
                        matrix[i - 1][j] - '0') + 1;

                    matrix[i][j] = (char) (value + 48);
                    max = Math.Max(max, matrix[i][j] - '0');
                }
            }
        }

        return max * max;
    }

    /*
     * 1 1 1
     * 1 1 1
     * 1 1 1
     *
     * take 2x2 squares and update bottom-right square
     * 1 1 1
     * 1 2 2
     * 1 2 3
     */
}