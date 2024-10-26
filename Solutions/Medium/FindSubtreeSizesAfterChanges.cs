namespace Sandbox.Solutions.Medium;

public class FindSubtreeSizesAfterChanges
{
    public class Node
    {
        public char Name { get; set; }
        public int Index { get; set; }
        public HashSet<Node> Children { get; set; } = [];
        public Node Parent { get; set; }
    }

    public int[] FindSubtreeSizes(int[] parent, string s)
    {
        var n = parent.Length;
        var dict = new Dictionary<int, Node>(n);

        for (int i = 0; i < n; i++)
        {
            var node = new Node { Index = i, Name = s[i] };
            dict.Add(i, node);
        }

        for (var i = 0; i < n; i++)
        {
            var node = dict[i];

            if (parent[i] != -1)
            {
                dict[parent[i]].Children.Add(node);
                node.Parent = dict[parent[i]];
            }
        }

        // from root (exclusive) down
        var root = dict[0];
        var result = new int[n];

        var d = new Dictionary<char, Node>(n);
        Preorder(root, d);

        // return subtree - node itself + all children
        CountChildren(root, result);
        return result;
    }

    public void Preorder(Node node, Dictionary<char, Node> dict)
    {
        if (dict.ContainsKey(node.Name))
        {
            // remove current child
            node.Parent.Children.Remove(node);

            node.Parent = dict[node.Name];
            dict[node.Name].Children.Add(node);
        }

        var newD = new Dictionary<char, Node>(dict);
        newD[node.Name] = node;

        foreach (var child in node.Children.ToList())
        {
            Preorder(child, newD);
        }
    }

    private int CountChildren(Node node, int[] result)
    {
        var childrenCount = node.Children.Sum(child => CountChildren(child, result));
        return result[node.Index] = 1 + childrenCount;
    }
}