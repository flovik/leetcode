namespace Sandbox.Solutions.Medium;

public class MapOfHighestPeak
{
    public int[][] HighestPeak(int[][] isWater)
    {
        var arr = new int[isWater.Length][];
        var visited = new bool[isWater.Length][];

        for (int i = 0; i < isWater.Length; i++)
        {
            arr[i] = new int[isWater[i].Length];
            Array.Fill(arr[i], int.MaxValue);
            visited[i] = new bool[isWater[i].Length];
        }

        // DFS, BFS, topo sort
        // starting point is water cell (may be multiple)
        // any two adjacent cells must have an absolute height difference of at most 1
        // need to find the maximum height in the matrix (a cell that has the highest value)
        // i, j, height
        var queue = new Queue<(int, int, int)>(isWater.Length * isWater[0].Length);

        for (int i = 0; i < isWater.Length; i++)
        {
            for (var j = 0; j < isWater[i].Length; j++)
            {
                if (isWater[i][j] == 1)
                    queue.Enqueue((i, j, 0));
            }
        }

        while (queue.Count > 0)
        {
            var (i, j, height) = queue.Dequeue();

            if (visited[i][j])
                continue;

            visited[i][j] = true;
            arr[i][j] = Math.Min(arr[i][j], height);

            // left, right, up, down
            if (i > 0 && !visited[i - 1][j])
                queue.Enqueue((i - 1, j, height + 1));
            if (j > 0 && !visited[i][j - 1])
                queue.Enqueue((i, j - 1, height + 1));
            if (i < isWater.Length - 1 && !visited[i + 1][j])
                queue.Enqueue((i + 1, j, height + 1));
            if (j < isWater[i].Length - 1 && !visited[i][j + 1])
                queue.Enqueue((i, j + 1, height + 1));
        }

        return arr;
    }
}