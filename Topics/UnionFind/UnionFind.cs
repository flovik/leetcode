namespace Sandbox.Topics.UnionFind;

// used to detect cycles in a graph
public class UnionFind
{
    private int[] parent;
    private int[] ranks;

    public UnionFind(int[] par)
    {
        parent = par;
    }

    // find parent of the node
    // flattens the tree
    public int FindWithPathCompression(int num)
    {
        if (parent[num] == num)
            return num;

        return parent[num] = FindWithPathCompression(parent[num]);
    }

    // find two nodes and assign to the same parent
    public bool UnionByRank(int left, int right)
    {
        var xParent = FindWithPathCompression(left);
        var yParent = FindWithPathCompression(right);

        // if same parent- then a cycle
        if (xParent == yParent)
            return false;

        // union by rank - join smaller ranked to bigger one
        if (ranks[xParent] > ranks[yParent])
            parent[yParent] = parent[xParent];
        else if (ranks[yParent] > ranks[xParent])
            parent[xParent] = parent[yParent];
        else
        {
            // attach the right node to the left one and increase height of X node by one
            parent[yParent] = xParent;
            ranks[xParent]++;
        }

        return true;
    }
}