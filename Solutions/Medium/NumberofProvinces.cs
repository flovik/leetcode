namespace Sandbox.Solutions.Medium;

public class NumberofProvinces
{
    public int FindCircleNum(int[][] isConnected)
    {
        var parent = Enumerable.Range(0, isConnected.Length).ToArray();
        var ranks = new int[isConnected.Length];
        Array.Fill(ranks, 1);

        for (var i = 0; i < isConnected.Length; i++)
        {
            for (var j = 0; j < isConnected[i].Length; j++)
            {
                if (i == j)
                    continue;

                if (isConnected[i][j] == 1)
                    Union(i, j);
            }
        }

        // we might have some nodes processed before, that couldn't change the parent to the real one
        for (int i = 0; i < parent.Length; i++)
        {
            Find(i);
        }

        var set = new HashSet<int>(parent);
        return set.Count;

        int Find(int num)
        {
            if (num == parent[num])
                return num;

            return parent[num] = Find(parent[num]);
        }

        bool Union(int left, int right)
        {
            var lp = Find(left);
            var rp = Find(right);

            if (lp == rp)
                return false;

            if (ranks[lp] > ranks[rp])
                parent[rp] = parent[lp];
            else if (ranks[rp] > ranks[lp])
                parent[lp] = parent[rp];
            else
            {
                ranks[lp]++;
                parent[rp] = lp;
            }

            return true;
        }
    }
}