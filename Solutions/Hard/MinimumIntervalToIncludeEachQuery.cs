namespace Sandbox.Solutions.Hard;

public class MinimumIntervalToIncludeEachQuery
{
    public int[] MinInterval(int[][] intervals, int[] queries)
    {
        // iterate intervals from left to right, since they are sorted
        // we need to track all intervals that belong to that query
        // we don't pop from min heap, because next queries also can be included in that interval, so popping occurs when
        // the end of the interval occurs
        // but in min heap we store a Tuple, which stores the size of the interval and the end of the interval
        // when all intervals until query are processed, keep the result for that query and pop some intervals that exceed the
        // current interval value (next queries won't be able to in that interval, because they are increasing)
        // when we get to the query bigger than current min heap, we start popping until we find the right interval (which will be the smallest
        // when we get to it
        var sortedQueries = new int[queries.Length];
        Array.Copy(queries, sortedQueries, queries.Length);

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        Array.Sort(sortedQueries);

        var answerIntervals = new Dictionary<int, int>();

        foreach (var query in queries)
            answerIntervals.TryAdd(query, -1);

        var minHeap = new PriorityQueue<(int, int), (int, int)>(intervals.Length);

        var i = 0;
        foreach (var query in sortedQueries)
        {
            while (i < intervals.Length && intervals[i][0] <= query)
            {
                var interval = intervals[i];
                var length = interval[1] - interval[0] + 1;
                minHeap.Enqueue((length, interval[1]), (length, interval[1]));
                i++;
            }

            while (minHeap.Count > 0 && query > minHeap.Peek().Item2)
                minHeap.Dequeue();

            if (minHeap.Count != 0)
                answerIntervals[query] = minHeap.Peek().Item1;
        }

        for (var j = 0; j < queries.Length; j++)
            queries[j] = answerIntervals[queries[j]];

        return queries;
    }
}