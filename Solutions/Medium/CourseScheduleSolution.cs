using System.Collections.Generic;

namespace Sandbox.Solutions.Medium;

public class CourseScheduleSolution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // find cycles in courses
        // create an adjacency list
        // perform topological sort - graph traversal in which each node v is visited only after all its dependencies are visited
        var adjacencyList = new LinkedList<int>[numCourses];
        for (var i = 0; i < numCourses; i++)
        {
            adjacencyList[i] = new LinkedList<int>();
        }

        foreach (var prerequisite in prerequisites)
        {
            adjacencyList[prerequisite[0]].AddLast(prerequisite[1]);
        }

        // loop through each node of the graph, initiate a dfs search that terminates when it hits any node that has already been visited
        // since the beginning of the topological sort or the node has no outgoing edges (a leaf node)

        // 0 is not visited yet, 1 is currently visiting and 2 is done visiting child nodes of a node
        var visitedNodes = new int[numCourses];

        return !adjacencyList.Where((linkedList, i) => linkedList.First is not null && IsCycle(linkedList.First, i)).Any();

        bool IsCycle(LinkedListNode<int> node, int id)
        {
            // if is currently visiting and got here, then it's a cycle
            if (visitedNodes[id] == 1)
                return true;

            if (visitedNodes[id] == 0)
            {
                // mark current node as currently visiting
                visitedNodes[id] = 1;

                while (node != null)
                {
                    var nextNode = adjacencyList[node.Value];
                    // if any of the adjacent nodes lead to cycles, then it's a cycle
                    // skip nodes that doesn't have any adjacent nodes
                    if (nextNode.First is not null && IsCycle(nextNode.First, node.Value))
                        return true;

                    node = node.Next;
                }
            }

            // no cycle happened before we get here, mark as visited
            visitedNodes[id] = 2;
            return false;
        }
    }
}