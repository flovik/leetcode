namespace Sandbox.Solutions.Medium;

public class MinimumScoreOfAPathBetweenTwoCities
{
    private Dictionary<int, List<int[]>> _dict;
    private bool[] _visited;

    public int MinScore(int n, int[][] roads)
    {
        _dict = new Dictionary<int, List<int[]>>(n);
        _visited = new bool[n + 1];

        for (int i = 1; i <= n; i++)
        {
            _dict.Add(i, []);
        }

        foreach (var road in roads)
        {
            _dict[road[0]].Add([road[1], road[2]]);
            _dict[road[1]].Add([road[0], road[2]]);
        }

        // DFS from 1, find n, along the way save the min of all edges
        return Dfs(1, n);
    }

    private int Dfs(int node, int n)
    {
        _visited[node] = true;

        var nodes = _dict[node];
        var nextMin = nodes.Where(e => !_visited[e[0]]).Select(e => Dfs(e[0], n)).ToList();
        var min2 = nextMin.Count > 0 ? nextMin.Min() : int.MaxValue;
        var min = Math.Min(nodes.Select(e => e[1]).Min(), min2);
        return min;
    }
}