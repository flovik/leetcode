namespace Sandbox.Topics.Trees.TopologicalSort;

// graph with directed edges where some events must occur before others
// school class prerequisites
// event scheduling
// program dependencies

// topological ordering - for each directed edge from node A to node B, node A appears before
// node B in the ordering

// topological sort finds the topological ordering in O(V+E)
// graph with cycles cannot have a valid ordering
public class TopologicalSort
{
    // pick unvisited node
    // DFS from selected node and explore unvisited nodes
    // on the callback of DFS, add current node to the topological ordering

    public void TopSort()
    {
        var visited = new HashSet<int>();

        // pick random node
        // visit children recursively using DFS
        // when all C visited, mark current node as visited

        void Dfs()
        {
        }
    }

    public void KahnsAlgorithm()
    {
        // repeatedly remove nodes without any dependencies from the graph and add them
        // to the topological ordering

        // as nodes without dependencies are removed from the graph, new nodes without dependencies should become free
        // we repeat removing nodes without dependencies from the graph until all nodes are processed, or a cycle si discovered

        // calculate in degree of nodes (incoming nodes)
        // maintain a queue of all nodes with no incoming edges
        // remove the node from the graph and subtract the degree of all affected nodes
        // add any new nodes in the queue
        // create adjacency list
        var prerequisites = new[] { new[] { 1, 4 }, new[] { 2, 4 }, new[] { 3, 1 }, new[] { 3, 2 } }
        var numCourses = 5;
        var adjList = new Dictionary<int, List<int>>(numCourses);
        var inDegree = new int[numCourses];

        foreach (var prerequisite in prerequisites)
        {
            //if (!Union(prerequisite[0], prerequisite[1]))
            //    return false;

            if (adjList.ContainsKey(prerequisite[0]))
                adjList[prerequisite[0]].Add(prerequisite[1]);
            else
                adjList.Add(prerequisite[0], new List<int>(numCourses) { prerequisite[1] });

            // increase in degree array
            inDegree[prerequisite[1]]++;
        }

        // kahn's
        var queue = new Queue<int>(numCourses);

        // add nodes with no incoming edges to the queue
        for (int i = 0; i < inDegree.Length; i++)
        {
            if (inDegree[i] != 0)
                continue;

            queue.Enqueue(i);
        }

        // remove nodes from queue and subtract affected nodes
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (adjList.TryGetValue(node, out var nodes))
            {
                foreach (var nd in nodes)
                {
                    inDegree[nd]--;

                    if (inDegree[nd] == 0)
                        queue.Enqueue(nd);
                }
            }
        }

        //return inDegree.All(a => a == 0);
    }
}