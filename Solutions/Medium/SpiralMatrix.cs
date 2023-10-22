namespace Sandbox.Solutions.Medium;

public class SpiralMatrix
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var columns = matrix.Length;
        var rows = matrix[0].Length;
        var result = new List<int>(columns * rows);
        int i = 0, j = -1;

        //repeat the cycle of going in a spiral manner until reach center
        while (result.Count != columns * rows)
        {
            //go right
            while (j != rows - 1)
            {
                if (matrix[i][j + 1] == -101) break;
                j++;
                result.Add(matrix[i][j]);
                matrix[i][j] = -101;
            }

            //go down
            while (i != columns - 1)
            {
                if (matrix[i + 1][j] == -101) break;
                i++;
                result.Add(matrix[i][j]);
                matrix[i][j] = -101;
            }

            //go left
            while (j != 0)
            {
                if (matrix[i][j - 1] == -101) break;
                j--;
                result.Add(matrix[i][j]);
                matrix[i][j] = -101;
            }

            //go up
            while (i != 0)
            {
                if(matrix[i - 1][j] == -101) break;
                i--;
                result.Add(matrix[i][j]);
                matrix[i][j] = -101;
            }
        }
        

        return result;
    }
}