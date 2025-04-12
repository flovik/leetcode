using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class LowestCommonAncestorOfDeepestLeaves
{
    private int maxDepth;
    private int count = 0;
    private TreeNode _answer;

    public TreeNode LcaDeepestLeaves(TreeNode root)
    {
        // lowest common ancestor of its deepest leavest
        // postorder
        // find deepest level nodes and save them
        // then, if both subtrees contain a deepest node, mark current one as the winning one
        // the last marked node (where both subtrees are true) then that one is the answer

        Dfs(root, 1);

        // only one leaf node, then it is the answer
        if (count == 1)
            return _answer;

        PostOrder(root, 1);
        return _answer;
    }

    public void Dfs(TreeNode root, int depth)
    {
        if (root == null)
            return;

        if (depth > maxDepth)
        {
            count = 0;
            _answer = root;
            maxDepth = depth;
        }

        if (depth == maxDepth)
            count++;

        Dfs(root.left, depth + 1);
        Dfs(root.right, depth + 1);
    }

    public bool PostOrder(TreeNode root, int depth)
    {
        if (root == null)
            return false;

        if (maxDepth == depth)
            return true;

        var left = PostOrder(root.left, depth + 1);
        var right = PostOrder(root.right, depth + 1);

        if (left && right)
            _answer = root;

        return left || right;
    }
}