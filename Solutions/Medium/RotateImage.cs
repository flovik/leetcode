namespace Sandbox.Solutions.Medium;

public class RotateImage
{
    public void Rotate(int[][] matrix)
    {
        for (int i = 0, j = matrix.Length - 1; i < j; i++, j--)
        {
            //preserve i and j to iterate inwards of matrix
            //row and column are used to move from the beginning of row until the end (j in my case)
            int row = i, column = j;
            //iterate current rows with to the last
            while (row < j)
            {
                var temp1 = matrix[row][j];
                matrix[row][j] = matrix[i][row];
                var temp2 = matrix[j][column];
                matrix[j][column] = temp1;
                temp1 = matrix[column][i];
                matrix[column][i] = temp2;
                matrix[i][row] = temp1;
                row++;
                column--;
            }
        }
    }
}