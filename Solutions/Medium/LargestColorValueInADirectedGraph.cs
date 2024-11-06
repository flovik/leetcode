namespace Sandbox.Solutions.Medium;

public class LargestColorValueInADirectedGraph
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        // use topological sort
        var n = colors.Length;
        var dict = new Dictionary<int, List<int>>(n);
        var inDegree = new int[n];
        var dp = new int[n][];
        var queue = new Queue<int>(n);

        for (int i = 0; i < n; i++)
        {
            dict.Add(i, []);
            dp[i] = new int[26];
        }

        foreach (var edge in edges)
        {
            dict[edge[0]].Add(edge[1]);
            inDegree[edge[1]]++;
        }

        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            var deq = queue.Dequeue();
            dp[deq][colors[deq] - 'a']++;

            var nodes = dict[deq];
            foreach (var node in nodes)
            {
                for (var j = 0; j < 26; j++)
                {
                    dp[node][j] = Math.Max(dp[deq][j], dp[node][j]);
                }

                inDegree[node]--;

                if (inDegree[node] == 0)
                    queue.Enqueue(node);
            }
        }

        if (inDegree.Any(e => e != 0))
            return -1;

        return dp.Aggregate(0, (current, node) => node.Prepend(current).Max());
    }
}