namespace Sandbox.Solutions.Medium;

public class NumberOfPairsOfInterchangeableRectangles
{
    public long InterchangeableRectangles(int[][] rectangles)
    {
        // [width, height]
        // interchangable - same width-to-height ratio
        var dict = new Dictionary<double, List<int[]>>(rectangles.Length);
        long pairs = 0;

        foreach (var rectangle in rectangles)
        {
            if (rectangle[1] == 0)
                continue;

            var ratio = (double)rectangle[0] / rectangle[1];

            dict.TryAdd(ratio, []);
            var len = dict[ratio].Count;
            pairs += len;

            dict[ratio].Add(rectangle);
        }

        // number of pairs
        return pairs;
    }
}