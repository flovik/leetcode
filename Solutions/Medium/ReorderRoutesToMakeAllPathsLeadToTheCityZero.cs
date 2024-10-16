namespace Sandbox.Solutions.Medium;

public class ReorderRoutesToMakeAllPathsLeadToTheCityZero
{
    public int MinReorder(int n, int[][] connections)
    {
        var visited = new bool[n];
        var q = new Queue<int[]>(n);
        var dict = new Dictionary<int, List<int[]>>(n);
        var count = 0;

        for (int i = 0; i < n; i++)
        {
            dict.Add(i, new List<int[]>());
        }

        foreach (var connection in connections)
        {
            dict[connection[0]].Add(connection);
            dict[connection[1]].Add(connection);

            if (connection[0] == 0 || connection[1] == 0)
                q.Enqueue(connection);
        }

        visited[0] = true;

        while (q.Count > 0)
        {
            var dq = q.Dequeue();
            var next = dq[0];

            // the dq[1] should be marked as visited, if not then we need to increment count and change the edge
            if (!visited[dq[1]])
            {
                count++;
                next = dq[1];
            }

            visited[next] = true;

            foreach (var con in dict[next])
            {
                if (next == con[0] && visited[con[1]] || next == con[1] && visited[con[0]])
                    continue;

                q.Enqueue(con);
            }
        }

        return count;
    }
}