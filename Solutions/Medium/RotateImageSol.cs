namespace Sandbox.Solutions.Medium;

public class RotateImageSol
{
    public void Rotate(int[][] matrix)
    {
        // go by outer layer of 2D matrix into inner layers one by one
        // save 4 numbers that should be rotated
        // swap those 4 numbers
        var queue = new Queue<int>(4);
        var start = 0;
        var end = matrix.Length - 1;

        while (start < end)
        {
            for (int i = start, j = end; i <= end - 1; i++, j--)
            {
                queue.Enqueue(matrix[start][i]);
                queue.Enqueue(matrix[i][end]);
                queue.Enqueue(matrix[end][j]);
                queue.Enqueue(matrix[j][start]);

                matrix[i][end] = queue.Dequeue();
                matrix[end][j] = queue.Dequeue();
                matrix[j][start] = queue.Dequeue();
                matrix[start][i] = queue.Dequeue();
            }

            start++;
            end--;
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.Write(matrix[i][j]);
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}