namespace Sandbox.Solutions.Medium;

public class MinCostToConnectAllPoints
{
    private class Point
    {
        public int[] XY { get; set; }
    }

    public int MinCostConnectPoints(int[][] points)
    {
        // should find the minimum spanning tree - connected graph (all vertices are connected)
        // in an undirected graph
        // to do that, use prim or kruskals algorithms, both run in O (E lg V)
        // kruskal uses union find
        // select and edge that has minimum weight and add that edge if it doesn't create cycle

        // 1. connect each and every vertex with each other
        var adjacencyList = new Dictionary<int[], Point>(points.Length);

        // initialize adjacency list
        foreach (var point in points)
        {
            adjacencyList.Add(point, new Point { XY = point });
        }

        // min heap to store minimum edges stored by weights W
        // edge to manhattan distance
        var pq = new PriorityQueue<(Point, Point), int>();

        // populate binary heap with edges
        for (var i = 0; i < points.Length; i++)
        {
            for (var j = 0; j < points.Length; j++)
            {
                if (i == j)
                    continue;

                var from = points[i];
                var to = points[j];

                var distance = Math.Abs(from[0] - to[0]) + Math.Abs(from[1] - to[1]);

                pq.Enqueue((adjacencyList[from], adjacencyList[to]), distance);
            }
        }

        var unionFind = new PointUnionFind(points.Length);

        // make empty sets for each point
        unionFind.MakeSet(points);

        // find edge that has minimum weight and add that edge if it doesn't create cycles
        while (pq.Count != 0)
        {
            var edge = pq.Dequeue();
            unionFind.Union(edge.Item1.XY, edge.Item2.XY);
        }

        return unionFind.GetSum();
    }

    private class PointUnionFind
    {
        // each point represents a set on its own at the start
        private readonly IDictionary<int[], int[]> _unionSet;

        private int _sum;

        public PointUnionFind(int length)
        {
            _unionSet = new Dictionary<int[], int[]>(length);
        }

        public int GetSum()
        {
            return _sum;
        }

        public void MakeSet(int[][] points)
        {
            // if points to itself, then it's root node
            foreach (var point in points)
            {
                _unionSet.Add(point, point);
            }
        }

        /// <summary>
        /// find which component a particular element belongs to find the root
        /// of that component by following the parent nodes until a self loop is reached
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int[] Find(int[] point)
        {
            if (_unionSet[point][0] == point[0] && _unionSet[point][1] == point[1])
                return _unionSet[point];

            var root = _unionSet[point];
            return _unionSet[point] = Find(root);
        }

        /// <summary>
        /// to unify to elements find which are the root nodes of each component and
        /// if the root nodes are different make one of the root nodes be the parent of the other
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Union(int[] x, int[] y)
        {
            var root1 = Find(x);
            var root2 = Find(y);

            // if roots equals, then it forms a cycle
            if (root1 != root2)
            {
                _unionSet[root1] = root2;

                var distance = Math.Abs(x[0] - y[0]) + Math.Abs(x[1] - y[1]);
                _sum += distance;
            }
        }
    }
}