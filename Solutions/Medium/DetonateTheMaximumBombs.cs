namespace Sandbox.Solutions.Medium;

public class DetonateTheMaximumBombs
{
    public int MaximumDetonation(int[][] bombs)
    {
        var n = bombs.Length;

        // index of bomb to its bombs in radius
        var adjList = new Dictionary<int, List<int>>(n);

        for (var i = 0; i < n; i++)
        {
            adjList.TryAdd(i, []);
        }

        for (var i = 0; i < n; i++)
        {
            var bomb = bombs[i];

            for (var j = 0; j < n; j++)
            {
                var secondBomb = bombs[j];

                // same bomb
                if (i == j)
                    continue;

                if (IsInRadius(bomb[0], bomb[1], secondBomb[0], secondBomb[1], bomb[2]))
                    adjList[i].Add(j);
            }
        }

        var count = 0;
        for (var i = 0; i < n; i++)
        {
            count = Math.Max(count, Dfs(i, []));
        }

        return count;

        int Dfs(int bombId, HashSet<int> visited)
        {
            visited.Add(bombId);

            var bombsInRadius = adjList[bombId].Where(e => !visited.Contains(e)).ToList();

            foreach (var b in bombsInRadius)
            {
                visited.Add(b);
            }

            return 1 + bombsInRadius.Sum(nextBomb => Dfs(nextBomb, visited));
        }

        bool IsInRadius(int x1, int y1, int x2, int y2, int radius) =>
            Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) <= radius;
    }
}