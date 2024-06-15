namespace Sandbox.Topics.Trees.ShortestPath;

public class Dijkstras
{
    public int WeightedShortestPath(int[][] times, int n, int k)
    {
        // dijkstra  - shortest path
        // directed graph with weights, positive weights
        // nodes labeled 1 to n

        var adjacencyList = new LinkedList<(int, int)>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            adjacencyList[i] = new LinkedList<(int, int)>();
        }

        foreach (var time in times)
        {
            var from = time[0];
            var to = time[1];
            var w = time[2];

            adjacencyList[from].AddLast((to, w));
        }

        // keep the shortest distance of vertex v from the source in Distance table
        // Distance[v] hold the distance from s to v
        // the table holds the shortest distance from source s to each other vertex v
        // greedy method - pick the closest vertex to the source
        // uses priority queue to store unvisited vertices by distance from s
        var queue = new Queue<int>(n);
        var weight = new int[n + 1];
        var path = new int[n + 1];

        Array.Fill(weight, -1);

        weight[k] = 0;

        queue.Enqueue(k);

        var visited = new HashSet<int>(n);
        var pq = new PriorityQueue<int, int>(n);
        while (queue.Count != 0)
        {
            var from = queue.Dequeue();
            visited.Add(from);

            pq.EnqueueRange(adjacencyList[from]);

            while (pq.Count != 0)
            {
                pq.TryDequeue(out int to, out int w);
                if (weight[to] == -1 || weight[to] > weight[from] + w)
                {
                    weight[to] = weight[from] + w;
                    path[to] = from;
                }

                if (!visited.Contains(to))
                    queue.Enqueue(to);
            }
        }

        // if not everyone visited, then -1
        if (visited.Count != n)
            return -1;

        // return weight to get to
        return weight.Max();
    }
}