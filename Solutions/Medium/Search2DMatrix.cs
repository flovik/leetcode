namespace Sandbox.Solutions.Medium;

public class Search2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int i = 0, j = matrix[0].Length - 1;
        //take the upper rightmost int and compare to it, do linear search complexity O(m + n)
        while (true)
        {
            if (target == matrix[i][j]) return true;
            if (target < matrix[i][j])
            {
                if (j == 0) break;
                j--;
            }
            else if (target > matrix[i][j])
            {
                if(i == matrix.Length - 1) break;
                i++;
            }
        }

        return false;
    }
}