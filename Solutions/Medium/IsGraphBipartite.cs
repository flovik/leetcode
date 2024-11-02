namespace Sandbox.Solutions.Medium;

public class IsGraphBipartite
{
    public bool IsBipartite(int[][] graph)
    {
        // bipartite - nodes can be partitioned into two sets A and B such that every edge connects a node in set A and a node in set B
        // color the graph with 2 colors such that no adjacent nodes have same color
        // so any new node shouldn't be part of two sets simultaneously
        var n = graph.Length;
        var setA = new HashSet<int>(n);
        var setB = new HashSet<int>(n);

        Dictionary<bool, HashSet<int>> setsDictionary = new()
        {
            { false, setA },
            { true, setB }
        };

        var visited = new bool[n];
        var queue = new Queue<(int, bool)>(n);

        for (var i = 0; i < graph.Length; i++)
        {
            if (visited[i])
                continue;

            queue.Enqueue((i, false));

            while (queue.Count > 0)
            {
                var (node, setKey) = queue.Dequeue();
                visited[node] = true;

                var set = setsDictionary[setKey];

                foreach (var nextNode in graph[node])
                {
                    if (!visited[nextNode])
                    {
                        queue.Enqueue((nextNode, !setKey));
                    }
                }

                // if node is part of another set
                var anotherSet = setsDictionary[!setKey];
                if (anotherSet.Contains(node))
                    return false;

                set.Add(node);
            }
        }

        return true;
    }
}