namespace Sandbox.Topics.Trees.ShortestPath;

public class Kruskal
{
    private int KruskalSol(int[][] points)
    {
        // kruskal
        // select minimal cost edges
        // and exclude it if it creates a cycle
        // create adj.list
        var parent = new Dictionary<int[], int[]>(1000);
        var ranks = new Dictionary<int[], int>(1000);

        foreach (var point in points)
        {
            parent.Add(point, point);
            ranks.Add(point, 1);
        }

        var pq = new PriorityQueue<(int[], int[]), int>(points.Length);

        // create all edges between points
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = 0; j < points.Length; j++)
            {
                if (i == j)
                    continue;

                pq.Enqueue((points[i], points[j]), GetDistance(points[i], points[j]));
            }
        }

        var sum = 0;
        var addedEdges = 0;

        while (pq.Count > 0)
        {
            // nodes - 1 = edges to be MST
            if (addedEdges == points.Length - 1)
                break;

            var (from, to) = pq.Dequeue();

            if (!Union(from, to))
                continue;

            sum += GetDistance(from, to);
        }

        return sum;

        int[] Find(int[] x)
        {
            if (x == parent[x])
                return x;

            return parent[x] = Find(parent[x]);
        }

        bool Union(int[] x, int[] y)
        {
            var xp = Find(x);
            var yp = Find(y);

            if (xp == yp)
                return false;

            if (ranks[xp] > ranks[yp])
                parent[yp] = parent[xp];
            else if (ranks[yp] > ranks[xp])
                parent[xp] = parent[yp];
            else
            {
                ranks[xp]++;
                parent[yp] = xp;
            }

            return true;
        }

        int GetDistance(int[] a, int[] b) => Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
    }
}