using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

internal class BinaryTreeRightSideView
{
    // by the requirements of the problem, max depth is only 100, so can create a list of 100 nodes
    private readonly int[] _nodesValues = new int[100];

    private int _maxDepth;

    public IList<int> RightSideView(TreeNode root)
    {
        // one thing is to use postOrder
        // iterate the tree with postOrder, you will get to the deepest node, which is OK
        // imagine the depth you get to is 5
        // when you iterate with postOrder, you will pass left side of the tree, then when you get to the
        // right side of the tree, depending on the depth you currently are, you will replace the depth from left side with the new
        // node found in the right side
        // the result array will keep track of the depth (if no node at the index, add otherwise update)
        if (root == null)
            return new List<int>();

        Postorder(root, 0);
        return _nodesValues[..(_maxDepth + 1)];
    }

    private void Postorder(TreeNode root, int currentDepth)
    {
        // update current depth as we go deeper into the tree
        if (root.left != null)
            Postorder(root.left, currentDepth + 1);

        if (root.right != null)
            Postorder(root.right, currentDepth + 1);

        if (currentDepth > _maxDepth)
            _maxDepth = currentDepth;

        // add or update the current node in array
        _nodesValues[currentDepth] = root.val;
    }

    // also BFS and taking last element can do the trick
}