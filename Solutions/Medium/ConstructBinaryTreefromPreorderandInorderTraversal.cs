using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class ConstructBinaryTreefromPreorderandInorderTraversal
{
    private readonly Dictionary<int, int> _tree = new();

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        // find index of right child of current node in the preOrder
        // index of current node in the preOrder - is the root of a subtree
        // preOrder always visit all the nodes on the left branch before going to the right
        // (we can immediately skip all the nodes on the left subtree of current node
        // to do that you use inOrder, when we find the root in inOrder we exactly know how many nodes are on the left
        // subtree and how many are on the right subtree
        // therefore, right child index is preStart (index of current preorder node) + numsOnLeft (all the nodes in the left subtree) + 1
        // numsOnLeft = root - inStart

        for (int i = 0; i < inorder.Length; i++)
        {
            _tree.Add(inorder[i], i);
        }

        return SetLeftAndRight(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }

    private TreeNode SetLeftAndRight(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
    {
        // break out of recursion
        if (preStart > preEnd || inStart > inEnd)
            return null;

        // current preOrder node is the root
        var root = new TreeNode(preorder[preStart]);

        // get current position of the root in inOrder array
        var rootInOrderPosition = _tree[root.val];

        // to find the right node, you need to remove the left subtree (inStart is the previous root node)
        // think about when we go one node deeper to the right, we can't consider the left subtree of the previous root
        var leftSubTreeNodesCount = rootInOrderPosition - inStart;

        // we know that in preOrder the next node is the left one for the root, so take the next one
        // preEnd is the end of the left subtree in preOrder (it is used to break out of recursion)
        // as you take a closer look at the inOrder, the inStart and rootInOrderPosition - 1 are the same nodes in the preOrder between
        // preStart and preEnd
        root.left = SetLeftAndRight(
            preorder, preStart + 1, preStart + leftSubTreeNodesCount,
            inorder, inStart, rootInOrderPosition - 1);

        // we know that inOrder has the length of the nodes in the left and right subtrees
        // so preStart + leftSubTreeNodesCount + 1 will get precisely the right node, and preEnd is the right subtree
        // rootInOrderPosition + 1 is the right subtree from the current root
        root.right = SetLeftAndRight(
            preorder, preStart + leftSubTreeNodesCount + 1, preEnd,
            inorder, rootInOrderPosition + 1, inEnd);

        return root;
    }
}