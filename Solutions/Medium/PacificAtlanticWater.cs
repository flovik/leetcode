namespace Sandbox.Solutions.Medium;

public class PacificAtlanticWater
{
    //if got to already valid point, no need to make more calculations
    private readonly ISet<(int i, int j)> _canSet = new HashSet<(int i, int j)>();

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        //bfs matrix
        var result = new List<IList<int>>();
        var visited = new HashSet<(int, int)>();

        for (int i = 0; i < heights.Length; i++)
        {
            for (int j = 0; j < heights[i].Length; j++)
            {
                visited.Clear();
                //put both together
                if (CanAtlanticCanPacific(heights, i, j, visited))
                {
                    _canSet.Add(new ValueTuple<int, int>(i, j));
                    var res = new List<int> { i, j };
                    result.Add(res);
                }
            }
        }

        return result;
    }

    private bool CanAtlanticCanPacific(int[][] heights, int ii, int jj, HashSet<(int, int)> visited)
    {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((ii, jj));

        bool pacific = false, atlantic = false;
        while (queue.Count != 0)
        {
            var pair = queue.Dequeue();
            int i = pair.Item1;
            int j = pair.Item2;

            if (_canSet.Contains((i, j))) return true;

            if (i == 0 ||
                j == 0) pacific = true;

            if (i == heights.Length - 1 ||
                j == heights[i].Length - 1) atlantic = true;

            if (pacific && atlantic) return true;

            visited.Add((i, j));

            //up
            if (i != 0 && !visited.Contains((i - 1, j)) && heights[i - 1][j] <= heights[i][j])
            {
                queue.Enqueue((i - 1, j));
            }

            //left
            if (j != 0 && !visited.Contains((i, j - 1)) && heights[i][j - 1] <= heights[i][j])
            {
                queue.Enqueue((i, j - 1));
            }

            //right
            if (j != heights[i].Length - 1 && heights[i][j + 1] <= heights[i][j] && !visited.Contains((i, j + 1)))
            {
                queue.Enqueue((i, j + 1));
            }

            //down
            if (i != heights.Length - 1 && heights[i + 1][j] <= heights[i][j] && !visited.Contains((i + 1, j)))
            {
                queue.Enqueue((i + 1, j));
            }


        }

        return false;
    }
}