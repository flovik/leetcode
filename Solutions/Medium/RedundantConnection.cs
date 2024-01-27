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
}