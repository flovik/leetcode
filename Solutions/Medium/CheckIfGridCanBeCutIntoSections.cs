namespace Sandbox.Solutions.Medium;
public class CheckIfGridCanBeCutIntoSections
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        // each section containts at least one rectangle
        // every rectangle belongs to exactly one section

        // calculate all lines for each line and find out which vertical lines are left
        // and which horizontal lines are left

        var x = new int[rectangles.Length][];
        var y = new int[rectangles.Length][];

        for (int i = 0; i < rectangles.Length; i++)
        {
            var rect = rectangles[i];

            x[i] = [rect[0], rect[2]];
            y[i] = [rect[1], rect[3]];
        }

        Array.Sort(x, (a, b) => a[0].CompareTo(b[0]));
        Array.Sort(y, (a, b) => a[0].CompareTo(b[0]));

        var list = new List<int[]>(x.Length) { x[0] };

        // merge X intervals
        for (int i = 1; i < x.Length; i++)
        {
            if (x[i][0] < list[^1][1])
            {
                list[^1][0] = Math.Min(list[^1][0], x[i][0]);
                list[^1][1] = Math.Max(list[^1][1], x[i][1]);
            }
            else
            {
                list.Add(x[i]);
            }
        }

        // can be cut if we have 3 sections
        if (list.Count > 2)
            return true;

        list.Clear();
        list.Add(y[0]);

        // merge Y intervals
        for (int i = 1; i < y.Length; i++)
        {
            if (y[i][0] < list[^1][1])
            {
                list[^1][0] = Math.Min(list[^1][0], y[i][0]);
                list[^1][1] = Math.Max(list[^1][1], y[i][1]);
            }
            else
            {
                list.Add(y[i]);
            }
        }

        if (list.Count > 2)
            return true;

        return false;
    }
}
