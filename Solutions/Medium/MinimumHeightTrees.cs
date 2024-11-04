namespace Sandbox.Solutions.Medium;

public class MinimumHeightTrees
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n == 0)
            return [];

        if (n == 1)
            return [0];

        // return list of all root nodes that are Minimum Height Trees, min(h)
        // a tree can have at most 2 MHTs!
        var dict = new Dictionary<int, List<int>>(n);
        var degree = new int[n];

        for (int i = 0; i < n; i++)
        {
            dict.Add(i, []);
        }

        foreach (var edge in edges)
        {
            dict[edge[0]].Add(edge[1]);
            dict[edge[1]].Add(edge[0]);
            degree[edge[1]]++;
            degree[edge[0]]++;
        }

        var queue = new Queue<int>(n);
        for (int i = 0; i < n; i++)
        {
            if (degree[i] == 1)
                queue.Enqueue(i);
        }

        var set = new HashSet<int>(n);

        while (queue.Count > 0)
        {
            set.Clear();
            var count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var deq = queue.Dequeue();
                degree[deq]--;
                set.Add(deq);

                var nodes = dict[deq];
                foreach (var node in nodes)
                {
                    degree[node]--;

                    if (degree[node] == 1)
                        queue.Enqueue(node);
                }
            }
        }

        return set.ToList();
    }

    public IList<int> FindMinHeightTreesBFS(int n, int[][] edges)
    {
        // BFS TLE
        // return list of all root nodes that are Minimum Height Trees, min(h)
        var dict = new Dictionary<int, List<int>>(n);

        for (int i = 0; i < n; i++)
        {
            dict.Add(i, []);
        }

        foreach (var edge in edges)
        {
            dict[edge[0]].Add(edge[1]);
            dict[edge[1]].Add(edge[0]);
        }

        var result = new int[n];

        var queue = new Queue<int>(n);
        var visited = new bool[n];
        var min = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            var height = 0;
            queue.Enqueue(i);
            visited[i] = true;

            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (int j = 0; j < count; j++)
                {
                    var deq = queue.Dequeue();
                    visited[deq] = true;

                    var nodes = dict[deq];
                    foreach (var node in nodes.Where(e => !visited[e]))
                    {
                        queue.Enqueue(node);
                    }
                }

                height++;
            }

            min = Math.Min(min, height);
            result[i] = height;
            Array.Fill(visited, false);
        }

        var list = new List<int>(n);

        for (int i = 0; i < n; i++)
        {
            if (result[i] != min)
                continue;

            list.Add(i);
        }

        return list;
    }
}