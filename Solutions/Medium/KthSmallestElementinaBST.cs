using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class KthSmallestElementinaBST
{
    private int _result = -1;
    private int _k;

    public int KthSmallest(TreeNode root, int k)
    {
        // inOrder BST will give the ordered sequence of values
        _k = k;
        Inorder(root);
        return _result;
    }

    private void Inorder(TreeNode root)
    {
        if (_k == 0)
            return;

        if (root.left != null)
            Inorder(root.left);

        _k--;
        if (_k == 0)
            _result = root.val;

        if (root.right != null)
            Inorder(root.right);
    }
}