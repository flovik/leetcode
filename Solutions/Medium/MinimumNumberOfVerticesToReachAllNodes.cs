namespace Sandbox.Solutions.Medium;

public class MinimumNumberOfVerticesToReachAllNodes
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var inDegree = new int[n];

        foreach (var edge in edges)
        {
            inDegree[edge[1]]++;
        }

        var list = new List<int>(n);
        for (var i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
                list.Add(i);
        }

        return list;
    }
}