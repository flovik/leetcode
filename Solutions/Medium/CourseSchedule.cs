namespace Sandbox.Solutions.Medium;

public class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // detect cycle in a graph with DFS
        // visit each node and check if it has a cycle
        // repeat for each node
        var graph = new List<List<int>>();
        for (int i = 0; i < numCourses; i++)
        {
            graph.Add(new List<int>());
        }

        foreach (var edge in prerequisites)
        {
            graph[edge[1]].Add(edge[0]);
        }

        var visited = new int[numCourses]; // visited is for ALREADY visited nodes

        for (int i = 0; i < numCourses; i++)
        {
            if (HasCycle(graph, i, visited))
            {
                return false;
            }
        }

        return true;
    }

    private bool HasCycle(IReadOnlyList<List<int>> graph, int node, int[] visited)
    {
        visited[node] = 1; //mark as visiting (currently)
        var children = graph[node];

        foreach (var child in children)
        {
            switch (visited[child])
            {

                case 1: // has been visited while visiting its children - cycle
                case 0 when HasCycle(graph, child, visited):
                    return true;
            }
        }

        visited[node] = 2; // mark as visited
        return false;
    }
}