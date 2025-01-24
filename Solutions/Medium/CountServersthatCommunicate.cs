namespace Sandbox.Solutions.Medium;

public class CountServersthatCommunicate
{
    public int CountServers(int[][] grid)
    {
        var rows = new List<int>(grid.Length);
        var cols = new List<int>(grid[0].Length);
        var cells = new HashSet<(int, int)>(grid.Length * grid[0].Length);

        for (int i = 0; i < grid[0].Length; i++)
        {
            if (ScanColumn(i))
                cols.Add(i);
        }

        for (int i = 0; i < grid.Length; i++)
        {
            if (ScanRow(i))
                rows.Add(i);
        }

        for (int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];
            for (var j = 0; j < grid[row].Length; j++)
            {
                if (grid[row][j] == 1)
                    cells.Add((row, j));
            }
        }

        for (int i = 0; i < cols.Count; i++)
        {
            var col = cols[i];
            for (var j = 0; j < grid.Length; j++)
            {
                if (grid[j][col] == 1)
                    cells.Add((j, col));
            }
        }

        return cells.Count;

        bool ScanRow(int rowIndex)
        {
            var count = 0;
            for (var i = 0; i < grid[0].Length; i++)
            {
                if (grid[rowIndex][i] == 1)
                    count++;

                if (count > 1)
                    return true;
            }

            return false;
        }

        bool ScanColumn(int colIndex)
        {
            var count = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                if (grid[i][colIndex] == 1)
                    count++;

                if (count > 1)
                    return true;
            }

            return false;
        }
    }
}