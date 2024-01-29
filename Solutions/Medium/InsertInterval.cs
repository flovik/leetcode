namespace Sandbox.Solutions.Medium;

public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var resultIntervals = new List<int[]>(intervals.Length);
        var i = 0;

        // leave intervals before new interval intact
        while (i < intervals.Length && intervals[i][1] < newInterval[0])
            resultIntervals.Add(intervals[i++]);

        // merge all overlapping intervals to new Interval
        while (i < intervals.Length && intervals[i][0] <= newInterval[1])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }

        // add the union of intervals
        resultIntervals.Add(newInterval);

        // add the rest
        while (i < intervals.Length)
            resultIntervals.Add(intervals[i++]);

        return resultIntervals.ToArray();
    }
}