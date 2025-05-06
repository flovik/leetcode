namespace Sandbox.Solutions.Medium;

public class NumberOfOperationsToMakeNetworkConnected
{
    public int MakeConnected(int n, int[][] connections)
    {
        if (n > connections.Length + 1)
            return -1;

        // union find
        var unionFind = new NetworkUnionFind(n);

        foreach (var connection in connections)
        {
            unionFind.Union(connection[0], connection[1]);
        }

        return unionFind.GetDisconnectedComponentsCount() - 1; // - 1 to ignore the main parent
    }

    class NetworkUnionFind
    {
        private readonly int[] _parent;

        public NetworkUnionFind(int n)
        {
            _parent = Enumerable.Range(0, n).ToArray();
        }

        private int Find(int target)
        {
            if (_parent[target] == target)
                return _parent[target];

            return _parent[target] = Find(_parent[target]);
        }

        public bool Union(int x, int y)
        {
            var parentX = Find(x);
            var parentY = Find(y);

            if (parentX == parentY)
                return false;

            _parent[parentY] = parentX;
            return true;
        }

        public int GetDisconnectedComponentsCount() => _parent.Where((t, i) => t == i).Count();
    }
}