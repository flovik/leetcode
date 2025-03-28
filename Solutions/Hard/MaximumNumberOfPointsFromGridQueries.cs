using System;

namespace Sandbox.Solutions.Hard;

public class MaximumNumberOfPointsFromGridQueries
{
    private int[][] directions = [[0, 1], [1, 0], [-1, 0], [0, -1]];
    private HashSet<(int, int)> visited = [];

    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        var values = new int[queries.Length];
        var sortedQueries = new (int, int)[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            sortedQueries[i] = (queries[i], i);
        }

        Array.Sort(sortedQueries, (a, b) => a.Item1.CompareTo(b.Item1));

        // bfs graph
        var pq = new PriorityQueue<(int, int), int>(queries.Length);
        pq.Enqueue((0, 0), grid[0][0]);
        visited.Add((0, 0));

        var sortedQueriesIndex = 0;
        var cellCount = 0;

        while (sortedQueriesIndex < queries.Length)
        {
            var query = sortedQueries[sortedQueriesIndex].Item1;

            // pq contains values already bigger than the current query, so it's alright to assume that all
            // queries to come after (because it's sorted) will not satisfy that condition

            while (pq.Count > 0 && pq.TryPeek(out var _, out var gridValue) && gridValue < query)
            {
                var (x, y) = pq.Dequeue();
                cellCount++;

                foreach (var direction in directions)
                {
                    var nx = x + direction[0];
                    var ny = y + direction[1];
                    if (!IsValidDirection(nx, ny, grid.Length, grid[0].Length))
                        continue;

                    visited.Add((nx, ny));
                    pq.Enqueue((nx, ny), grid[nx][ny]);
                }
            }

            // for all queries with the same or lower threshold, answer is the curCellCount
            while (sortedQueriesIndex < queries.Length && sortedQueries[sortedQueriesIndex].Item1 <= query)
            {
                values[sortedQueries[sortedQueriesIndex].Item2] = cellCount;
                sortedQueriesIndex++;
            }
        }

        return values;
    }

    private bool IsValidDirection(int x, int y, int m, int n) => x >= 0 && y >= 0 && x < m && y < n && !visited.Contains((x, y));
}