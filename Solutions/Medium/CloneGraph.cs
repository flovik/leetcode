namespace Sandbox.Solutions.Medium;

public class CloneGraphSolution
{
    private readonly IDictionary<int, GraphNode> _nodesDictionary = new Dictionary<int, GraphNode>();

    public GraphNode CloneGraph(GraphNode node)
    {
        // deep copy of a connected undirected graph
        // create map of old nodes to new nodes based on the value of old node (hash code is fine too)

        // iterate each node and add them to the dictionary
        if (node is null)
            return null;

        var queue = new Queue<GraphNode>();
        queue.Enqueue(node);

        while (queue.Count != 0)
        {
            var temp = queue.Dequeue();
            _nodesDictionary.TryAdd(temp.val, new GraphNode(temp.val)); // might exist already

            foreach (var neighbor in temp.neighbors)
            {
                if (!_nodesDictionary.ContainsKey(neighbor.val))
                {
                    _nodesDictionary.Add(new KeyValuePair<int, GraphNode>(neighbor.val, new GraphNode(neighbor.val)));
                    queue.Enqueue(neighbor);
                }

                _nodesDictionary[temp.val].neighbors.Add(_nodesDictionary[neighbor.val]);
            }
        }

        return _nodesDictionary[node.val];
    }
}

public class GraphNode
{
    public int val;
    public IList<GraphNode> neighbors;

    public GraphNode()
    {
        val = 0;
        neighbors = new List<GraphNode>();
    }

    public GraphNode(int _val)
    {
        val = _val;
        neighbors = new List<GraphNode>();
    }

    public GraphNode(int _val, List<GraphNode> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}