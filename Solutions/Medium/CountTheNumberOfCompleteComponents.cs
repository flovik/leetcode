namespace Sandbox.Solutions.Medium;

public class CountTheNumberOfCompleteComponents
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        var result = 0;

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

        // iterate each vertex, and consider the length of current vertex
        // each vertex of that list should have the same count as the initial vertex
        // because it should be connected, every vertex should be connected to every another
        // vertex to form a component
        // every vertex should have (total number of vertices - 1) number of vertices

        var visited = new bool[n];
        var set = new HashSet<int>(n);
        foreach (var (node, edgeList) in dict)
        {
            if (visited[node])
                continue;

            var count = edgeList.Count;

            var isConnected = true;
            var connectedNodes = Dfs(node);

            var numberOfEdgesPerVertex = set.Count - 1;
            if (count + connectedNodes != set.Count * numberOfEdgesPerVertex)
                isConnected = false;

            if (isConnected)
                result++;

            visited[node] = true;
            set.Clear();
        }

        return result;

        int Dfs(int node)
        {
            if (visited[node])
                return 1;

            visited[node] = true;
            set.Add(node);

            var nextNodes = dict[node];

            var connectedNodes = 0;

            foreach (var nextNode in nextNodes)
            {
                connectedNodes += Dfs(nextNode);
            }

            return connectedNodes;
        }
    }
}