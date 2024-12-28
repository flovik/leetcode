namespace Sandbox.Solutions.Medium;

public class BrickWall
{
    public int LeastBricks(IList<IList<int>> wall)
    {
        var count = wall.Count;
        var dict = new Dictionary<int, int>(count);

        foreach (var row in wall)
        {
            var holePosition = 0;

            // calculate 'holes' in the row
            for (var i = 0; i < row.Count - 1; i++)
            {
                holePosition += row[i];
                dict.TryAdd(holePosition, 0);
                dict[holePosition]++;
            }
        }

        // most holes means the best line
        var max = 0;
        foreach (var value in dict.Values.Where(value => value > max))
        {
            max = value;
        }

        return count - max;
    }
}