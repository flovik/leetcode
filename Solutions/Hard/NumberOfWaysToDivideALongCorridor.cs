namespace Sandbox.Solutions.Hard;

public class NumberOfWaysToDivideALongCorridor
{
    public int NumberOfWays(string corridor)
    {
        // each section has exactly two seats with any number of plants
        const int mod = 1_000_000_007;

        // number of seats must be even
        var seats = corridor.Count(e => e == 'S');
        if (seats < 2 || seats % 2 == 1)
            return 0;

        // find product of all possible positions between every two adjacent segments
        long ways = 1;

        // between segments are K plants, then K + 1 is the answer for that segment
        int firstSegmentLeft = corridor.IndexOf('S'),
            firstSegmentRight = corridor.IndexOf('S', firstSegmentLeft + 1),
            secondSegmentLeft = 0,
            secondSegmentRight = 0;

        while (secondSegmentRight < corridor.Length)
        {
            secondSegmentLeft = corridor.IndexOf('S', firstSegmentRight + 1);
            secondSegmentRight = corridor.IndexOf('S', secondSegmentLeft + 1);

            if (secondSegmentLeft == -1)
                break;

            var value = secondSegmentLeft - firstSegmentRight;
            ways = ways * value % mod;

            firstSegmentLeft = secondSegmentLeft;
            firstSegmentRight = secondSegmentRight;
        }

        return (int)(ways % mod);
    }
}