namespace Sandbox.Solutions.Medium;

public class CourseSchedule2
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // adjacency list (array of linked lists)
        // check using coloring algorithm if it has cycles
        var adjacencyList = new LinkedList<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            adjacencyList[i] = new LinkedList<int>();
        }

        foreach (var prerequisite in prerequisites)
        {
            adjacencyList[prerequisite[0]].AddLast(prerequisite[1]);
        }

        // visited array to keep track of visited nodes
        var visited = new int[numCourses];
        var coursesQueue = new Queue<int>(numCourses);

        for (var i = 0; i < adjacencyList.Length; i++)
        {
            var node = adjacencyList[i].First;
            if (node is not null && IsCycle(node, i))
                return Array.Empty<int>();

            if (visited[i] == 2)
                continue;

            coursesQueue.Enqueue(i);
            visited[i] = 2;
        }

        return coursesQueue.ToArray();

        bool IsCycle(LinkedListNode<int> node, int id)
        {
            if (visited[id] == 1)
                return true;

            if (visited[id] == 0)
            {
                visited[id] = 1;
                // iterate each adjacent nodes to find cycles
                while (node != null)
                {
                    var nextNode = adjacencyList[node.Value];
                    if (nextNode.First is not null && IsCycle(nextNode.First, node.Value))
                        return true;

                    // mark the leaf node as visited and enqueue, because it should be one of the first
                    if (visited[node.Value] != 2)
                    {
                        coursesQueue.Enqueue(node.Value);
                        visited[node.Value] = 2;
                    }

                    node = node.Next;
                }
            }

            // when all adjacent nodes were visited, enqueue the visited node
            if (visited[id] != 2)
                coursesQueue.Enqueue(id);

            visited[id] = 2;
            return false;
        }
    }
}