namespace Sandbox.Solutions.Medium;

public class NonOverlappingIntervals
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (interval1, interval2) => interval1[0].CompareTo(interval2[0]));

        var result = 0;
        var endInterval = intervals[0][1];

        for (var i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] < endInterval)
            {
                endInterval = Math.Min(intervals[i][1], endInterval);
                result++;
            }
            else
                endInterval = intervals[i][1];
        }

        return result;
    }
}