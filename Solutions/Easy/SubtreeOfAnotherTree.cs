using Sandbox.DataStructures;

namespace Sandbox.Solutions.Easy;

public class SubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
            return false;

        if (root.val == subRoot.val && IsSame(root, subRoot))
            return true;

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsSame(TreeNode root, TreeNode sub)
    {
        // if leaf node and both are null it's ok (but when one leaf node and one null not ok)
        if (root == null || sub == null)
            return root == sub;

        if (root.val != sub.val)
            return false;

        return IsSame(root.left, sub.left) && IsSame(root.right, sub.right);
    }
}