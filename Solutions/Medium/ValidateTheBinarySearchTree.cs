using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class ValidateTheBinarySearchTree
{
    private bool _result = true;
    private long _previousValue = long.MinValue;

    public bool IsValidBST(TreeNode root)
    {
        // inOrdering a BST will give the nodes in an ascending order
        Inorder(root);
        return _result;
    }

    private void Inorder(TreeNode root)
    {
        if (!_result)
            return;

        if (root.left != null)
            Inorder(root.left);

        // previous value should be more or equal to previous value
        if (_previousValue >= root.val)
            _result = false;

        _previousValue = root.val;

        if (root.right != null)
            Inorder(root.right);
    }
}