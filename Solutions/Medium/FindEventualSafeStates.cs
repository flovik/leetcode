namespace Sandbox.Solutions.Medium;

public class FindEventualSafeStates
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        // safe node - if every path leads to a terminal node or safe node
        // find all incoming edges for each node
        // if it has no incoming, add them to PQ and subtract IN-degree nodes
        // from pq start doing repeating the same procedure until PQ is empty

        var n = graph.Length;
        var outDegree = new int[n];
        var toDictionary = new Dictionary<int, List<int>>(n);

        for (var i = 0; i < n; i++)
        {
            toDictionary.Add(i, []);
        }

        for (var i = 0; i < n; i++)
        {
            var node = graph[i];
            foreach (var toNode in node)
            {
                outDegree[i]++;
                toDictionary[toNode].Add(i);
            }
        }

        var pq = new PriorityQueue<int, int>(n);

        // all nodes that have 0 in-degree, add to the PQ as initial state
        for (int i = 0; i < n; i++)
        {
            if (outDegree[i] == 0)
                pq.Enqueue(i, 1);
        }

        while (pq.Count > 0)
        {
            var deq = pq.Dequeue();
            var to = toDictionary[deq];

            foreach (var i in to)
            {
                outDegree[i]--;

                if (outDegree[i] == 0)
                    pq.Enqueue(i, 1);
            }
        }

        // every 0 from outDegree is a safe node
        // should be in ascending
        var list = new List<int>(n);
        for (var i = 0; i < n; i++)
        {
            if (outDegree[i] == 0)
                list.Add(i);
        }

        return list;
    }
}