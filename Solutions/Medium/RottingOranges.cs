namespace Sandbox.Solutions.Medium;

public class RottingOranges
{
    public int OrangesRotting(int[][] grid)
    {
        // every minute, that is 4-directionally adjacent to a rotten orange becomes rotten
        // minimum number of minutes that must elapse
        var result = 0;
        var rottenCoordinates = new HashSet<(int, int)>();
        var freshOranges = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 2)
                    rottenCoordinates.Add((i, j));

                if (grid[i][j] == 1)
                    freshOranges++;
            }
        }

        // directions
        var dx = new[] { -1, 1, 0, 0 };
        var dy = new[] { 0, 0, -1, 1 };

        do
        {
            if (freshOranges == 0)
                break;

            var oldRottenOranges = rottenCoordinates.ToHashSet();
            foreach (var (y, x) in oldRottenOranges)
            {
                for (var i = 0; i < 4; i++)
                {
                    var newX = x + dx[i];
                    var newY = y + dy[i];

                    if (newX < 0 || newX >= grid[y].Length || newY < 0 || newY >= grid.Length ||
                        grid[newY][newX] != 1) continue;

                    rottenCoordinates.Add((newY, newX));
                    grid[newY][newX] = 2;
                    freshOranges--;
                }
            }

            if (oldRottenOranges.Count == rottenCoordinates.Count)
                return -1;

            result++;

        } while (true);


        return result;
    }
}