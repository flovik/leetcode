namespace Sandbox.Solutions.Medium;

public class PacificAtlanticWaterFlow
{
    private readonly IList<IList<int>> _resultList = new List<IList<int>>();
    private readonly ISet<(int, int)> _coordinatesSet = new HashSet<(int, int)>();
    private readonly ISet<(int, int)> _visitedCoordinates = new HashSet<(int, int)>();

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        // x == 0 || y == 0 => pacific true
        // x == heights.Length - 1 || y == heights[^1].Length - 1

        // if left, right, up and down is bigger than current number, you cannot go in there

        bool pacific = false, atlantic = false;

        for (var i = 0; i < heights.Length; i++)
        {
            for (var j = 0; j < heights[0].Length; j++)
            {
                _visitedCoordinates.Clear();
                pacific = false;
                atlantic = false;

                DfsCoordinates(j, i);
                if (!pacific || !atlantic)
                    continue;

                _resultList.Add(new List<int> { i, j });
                _coordinatesSet.Add((i, j));
            }
        }
        return _resultList;

        void DfsCoordinates(int x, int y)
        {
            if (_coordinatesSet.Contains((y, x)))
            {
                pacific = true;
                atlantic = true;
            }

            if (pacific && atlantic)
                return;

            if (x == 0 || y == 0)
                pacific = true;

            if (x == heights[^1].Length - 1 || y == heights.Length - 1)
                atlantic = true;

            _visitedCoordinates.Add((y, x));

            if (x > 0 && heights[y][x - 1] <= heights[y][x] &&
                !_visitedCoordinates.Contains((y, x - 1)))
                DfsCoordinates(x - 1, y);

            if (x < heights[^1].Length - 1 && heights[y][x + 1] <= heights[y][x] &&
                !_visitedCoordinates.Contains((y, x + 1)))
                DfsCoordinates(x + 1, y);

            if (y > 0 && heights[y - 1][x] <= heights[y][x] &&
                !_visitedCoordinates.Contains((y - 1, x)))
                DfsCoordinates(x, y - 1);

            if (y < heights.Length - 1 && heights[y + 1][x] <= heights[y][x] &&
                !_visitedCoordinates.Contains((y + 1, x)))
                DfsCoordinates(x, y + 1);
        }
    }
}