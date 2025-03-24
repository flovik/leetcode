namespace Sandbox.Solutions.Medium;
public class CountDaysWithoutMeetings
{
    public int CountDays(int days, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        var list = new List<int[]>(meetings.Length) { { [0, 0] } };

        // merge meetings
        for (int i = 0; i < meetings.Length; i++)
        {
            if (meetings[i][0] < list[^1][1])
            {
                list[^1][0] = Math.Min(meetings[i][0], list[^1][0]);
                list[^1][1] = Math.Max(meetings[i][1], list[^1][1]);
            }
            else
            {
                list.Add(meetings[i]);
            }
        }

        var sum = 0;

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i][0] == list[i - 1][1])
                continue;

            sum += (list[i][0] - list[i - 1][1] - 1);
        }

        sum += days - list[^1][1];
        return sum;
    }
}
