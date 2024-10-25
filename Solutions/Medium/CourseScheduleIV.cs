namespace Sandbox.Solutions.Medium;

public class CourseScheduleIV
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        var list = new bool[queries.Length];

        var pq = new PriorityQueue<int, int>(numCourses);
        var dict = new Dictionary<int, HashSet<int>>(numCourses);
        var preDict = new Dictionary<int, HashSet<int>>(numCourses);
        var outDegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            dict.Add(i, []);
            preDict.Add(i, []);
        }

        foreach (var t in prerequisites)
        {
            outDegree[t[0]]++;
            dict[t[1]].Add(t[0]);
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (outDegree[i] == 0)
                pq.Enqueue(i, 1);
        }

        while (pq.Count > 0)
        {
            var deq = pq.Dequeue();
            var set = dict[deq];
            var prereq = preDict[deq];

            foreach (var i in set)
            {
                outDegree[i]--;
                preDict[i].UnionWith(prereq);
                preDict[i].Add(deq);

                if (outDegree[i] == 0)
                    pq.Enqueue(i, 1);
            }
        }

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            if (preDict[query[0]].Contains(query[1]))
                list[i] = true;
        }

        return list.ToArray();
    }
}