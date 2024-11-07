namespace Sandbox.Solutions.Hard;

public class ParallelCoursesIII
{
    public int MinimumTime(int n, int[][] relations, int[] time)
    {
        var dict = new Dictionary<int, List<int>>(n);
        var outDegree = new int[n];

        for (int i = 1; i <= n; i++)
        {
            dict.Add(i, []);
        }

        foreach (var relation in relations)
        {
            dict[relation[1]].Add(relation[0]);
            outDegree[relation[0] - 1]++;
        }

        var queue = new PriorityQueue<int, int>(n);

        for (int i = 0; i < n; i++)
        {
            if (outDegree[i] == 0)
                queue.Enqueue(i + 1, time[i]);
        }

        var result = 0;
        while (queue.Count > 0)
        {
            queue.TryDequeue(out var deq, out var curTime);
            result = Math.Max(result, curTime);
            var nodes = dict[deq];
            foreach (var node in nodes)
            {
                outDegree[node - 1]--;

                if (outDegree[node - 1] == 0)
                    queue.Enqueue(node, curTime + time[node - 1]);
            }
        }

        return result;
    }
}