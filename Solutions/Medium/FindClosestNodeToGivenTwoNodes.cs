using System.Reflection.Metadata;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Sandbox.Solutions.Medium;

public class FindClosestNodeToGivenTwoNodes
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        var n = edges.Length;

        var queue = new Queue<int>(n);
        var node1Nodes = new int[n];
        var node2Nodes = new int[n];
        var visited = new bool[n];

        Array.Fill(node1Nodes, -1);
        Array.Fill(node2Nodes, -1);

        // process node 1
        queue.Enqueue(node1);
        ProcessGraph(node1Nodes, 0);

        Array.Fill(visited, false);

        queue.Enqueue(node2);
        ProcessGraph(node2Nodes, 0);

        // math max of both array, return the smallest value and index!
        var ans = int.MaxValue;
        var index = -1;

        for (int i = 0; i < n; i++)
        {
            if (node1Nodes[i] == -1 || node2Nodes[i] == -1)
                continue;

            var max = Math.Max(node1Nodes[i], node2Nodes[i]);
            if (max >= ans)
                continue;

            index = i;
            ans = max;
        }

        return index;

        void ProcessGraph(int[] nodes, int moves)
        {
            while (queue.Count > 0)
            {
                var deq = queue.Dequeue();

                nodes[deq] = moves;
                moves++;

                if (edges[deq] != -1 && !visited[edges[deq]])
                    queue.Enqueue(edges[deq]);

                visited[deq] = true;
            }
        }
    }
}