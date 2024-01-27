namespace Sandbox.Solutions.Medium;

public class RedundantConnection
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        // nodes are numerated from 1 to n and connected to each other, resulting
        // in a connected undirected graph
        // there may be edges that are redundant, return that edge
        var adjacencyList = new LinkedList<int>[edges.Length];

        for (var i = 0; i < edges.Length; i++)
            adjacencyList[i] = new LinkedList<int>();

        var visited = new HashSet<int>(edges.Length);

        // traverse graph DFS search see if we can connect u to v, if we can, it must be the duplicate edge
        // when you add a new edge to the graph and both of vertices have connections, check with DFS if it forms a cycle
        // cycle PREVENTION, build the graph one edge at a time, before adding check if there is a path already

        foreach (var edge in edges)
        {
            visited.Clear();
            if (adjacencyList[edge[0] - 1].Count != 0 && adjacencyList[edge[1] - 1].Count != 0 && Dfs(edge[0] - 1, edge[1] - 1))
                return edge;

            adjacencyList[edge[0] - 1].AddLast(edge[1] - 1);
            adjacencyList[edge[1] - 1].AddLast(edge[0] - 1);
        }

        return null;

        bool Dfs(int source, int target)
        {
            if (visited.Contains(source))
                return false;

            // mark as visited
            visited.Add(source);

            // 1. returned back where we started - a cycle
            // 2. the second is for going recursively to children of source node
            // that can eventually lead to source == target and form a cycle
            return source == target || adjacencyList[source].Any(edge => Dfs(edge, target));
        }
    }

    public int[] FindRedundantConnectionUnionFind(int[][] edges)
    {
        // if you connect one more edge to a connected loop, it will create a cycle
        // connected loop consists of N nodes and N-1 edges without cycles, adding one more edge will make it redundant
        // to find if that edge creates cycle, apply Union (by rank) and Find (by path compression)

        // just add edges by yourself and you'll see it yourself

        // each node's parent is itself at the start
        int[] parent = Enumerable.Range(0, edges.Length).ToArray();
        int[] ranks = new int[edges.Length];
        Array.Fill(ranks, 1);

        foreach (var edge in edges)
        {
            if (!UnionByRank(edge[0] - 1, edge[1] - 1))
                return edge;
        }

        return null;

        // find ID which represents the component that a node belongs to
        // path compression flattens the tree when calling find()
        // compression - make the found root as parent of X so that we don;t have to traverse all intermediate nodes again
        // https://www.youtube.com/watch?v=VHRhJWacxis&ab_channel=WilliamFiset
        int FindWithPathCompression(int x)
        {
            if (x == parent[x])
                return x;

            // update parent of x before returning for each call
            return parent[x] = FindWithPathCompression(parent[x]);
        }

        // join two components into a single component
        // find representative of x-component (find(x)) and y-component (find(y))
        // and assign them a common representative (same parent)
        // rank optimization makes the worst case from O(N) to O(log N)
        // https://www.youtube.com/watch?v=FXWRE67PLL0&t=3s&ab_channel=NeetCode
        // rank is the representative of the height of the tree of dsu
        bool UnionByRank(int x, int y)
        {
            var xParent = FindWithPathCompression(x);
            var yParent = FindWithPathCompression(y);

            // if same parent- then a cycle
            if (xParent == yParent)
                return false;

            // union by rank - join smaller ranked to bigger one
            if (ranks[xParent] > ranks[yParent])
                parent[yParent] = parent[xParent];
            else if (ranks[yParent] > ranks[xParent])
                parent[xParent] = parent[yParent];
            else
            {
                // attach the right node to the left one and increase height of X node by one
                parent[yParent] = xParent;
                ranks[xParent]++;
            }

            return true;
        }
    }
}

// that implementation is naive and works in O(n^2)
/*
   // Union Find is also a Data structure
 * // find ID which represents the component that a node belongs to
   int Find(int x)
   {
   // recursively search the parent while the node is itself
   while (x != parent[x])
   x = parent[x];

   return parent[x];
   }

   // that Union creates un optimized tree like a line looking like a linked list
   // join two components into a single component
   // find representative of x-component (find(x)) and y-component (find(y))
   // and assign them a common representative (same parent)
   bool Union(int x, int y)
   {
   var xParent = Find(x);
   var yParent = Find(x);

   // if same parent- then a cycle
   if (xParent == yParent)
   return false;

   // union smaller set to a bigger set
   parent[xParent] = yParent;
   return true;
   }

*/