using Sandbox.DataStructures;

namespace Sandbox.Solutions.Medium;

public class DeleteNodeBST
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        TreeNode prev = null;
        var current = root;
        while (current is not null && current.val != key)
        {
            prev = current;
            current = current.val < key ? current.right : current.left;
        }

        //return original tree
        if (current is null) return root;

        //delete root
        if (prev is null) return DeleteNode(current);

        if (prev.left is not null && prev.left.val == current.val) prev.left = DeleteNode(current);
        else prev.right = DeleteNode(current);

        return root;
    }

    private TreeNode DeleteNode(TreeNode root)
    {
        //no children
        if (root is null) return null;

        //1 right child
        if (root.left is null) return root.right;

        //1 left child
        if (root.right is null) return root.left;

        //2 children, inorder of right
        var next = root.right;
        var prev = new TreeNode();
        while (next.left is not null) //get leftmost node
        {
            prev = next;
            next = next.left;
        }

        //give the reference to new node of the old node
        next.left = root.left;
        if (root.right.val != next.val) //if have some nodes on the left until the leftmost
        {
            prev.left = next.right; //delete reference to swapped node
            next.right = root.right; //place to new node the right subtree
        }

        return next;
    }
}