namespace Sandbox.Solutions.Medium;

public class FirstCompletelyPaintedRowOrColumn
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        var dict = new Dictionary<int, (int, int)>(n * m);
        var rows = new int[n];
        Array.Fill(rows, m);

        var cols = new int[m];
        Array.Fill(cols, n);

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                dict.Add(mat[i][j], (i, j));
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            var (x, y) = dict[arr[i]];

            rows[x]--;
            cols[y]--;

            if (rows[x] == 0 || cols[y] == 0)
                return i;
        }

        return arr.Length - 1;
    }
}