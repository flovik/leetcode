namespace Sandbox.Solutions.Medium;

public class Triangle
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        // min path from top to bottom
        // on current index i, move to either index i or index i + 1
        for (var i = 1; i < triangle.Count; i++)
        {
            for (var j = 0; j < triangle[i].Count; j++)
            {
                if (j == 0)
                    triangle[i][j] += triangle[i - 1][j];
                else if (j == triangle[i].Count - 1)
                    triangle[i][j] += triangle[i - 1][j - 1];
                else
                    triangle[i][j] = Math.Min(triangle[i][j] + triangle[i - 1][j - 1], triangle[i][j] + triangle[i - 1][j]);
            }
        }

        return triangle[^1].Min();
    }
}