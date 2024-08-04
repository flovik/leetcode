namespace Sandbox.Topics.Trees.EulereanPath;

// Eulerian path, eulerian circuits
// path - path of edges that visits all the edges on a graph exactly once
// circuit - eulerian path that starts and ends on the same vertex
// O(E)
public class HierholzerAlgorithm
{
    // https://www.youtube.com/watch?v=8MpoO2zA2l4&ab_channel=WilliamFiset

    // step 1 - determine if that path exists, at most one vertex has (outdegree) - (indegree) = 1
    // and at most one vertex (indegree) - (outdegree) = 1, and all other vertices have equal in and out degrees
    // count in/out degrees of each node by looping thru all the edges
    // when that is done, verify that every node doesn't have diff of in and out > 1
    // ! if all in and out degrees are equal, then it's a eulerian circuit, and any non-zero degree is suitable
    // after validation, in array is not needed

    // step 2 - choose a valid starting node, the one with In = 1 is the starting
    // the one with Out = 1 is the final one

    // DFS thru the nodes and if we are stuck, meaning node has no unvisited outgoing edges, backtrack and add current node
    // to the front of the solution solution
    // when backtracking, if current node has any remaining unvisited edges, we follow them by calling our DFS to extend eulerian path
    // when edge is taken, reduce the outgoing edge count in the Out array
}