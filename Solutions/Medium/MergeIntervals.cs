namespace Sandbox.Solutions.Medium;

public class MergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        // sort un-sorted array
        Array.Sort(intervals, (interval1, interval2) => interval1[0].CompareTo(interval2[0]));

        var res = new List<int[]>(intervals.Length) {
            intervals[0] };

        var cur = 0;
        // find overlapping intervals and merge them

        for (var i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] >= res[cur][0] &&
                intervals[i][0] <= res[cur][1])
            {
                res[cur][0] = Math.Min(res[cur][0], intervals[i][0]);
                res[cur][1] = Math.Max(res[cur][1], intervals[i][1]);
            }
            else
            {
                res.Add(intervals[i]);
                cur++;
            }
        }

        return res.ToArray();
    }
}