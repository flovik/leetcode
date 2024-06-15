using System.IO;

namespace Sandbox.Topics.Trees;

// root - the parent
// height - the deepest child of the tree
// binary tree - tree with at max 2 children (left and right)
// binary search tree - binary tree with ordering
// balanced - the same height
public class Tree<T>
{
    private BinaryNode<T> _root;

    public Tree(T value)
    {
        _root = new BinaryNode<T>(value);
    }

    #region Search

    public void BFS(BinaryNode<T> node)
    {
        var queue = new Queue<BinaryNode<T>>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var levelNodes = queue.Count;

            for (int i = 0; i < levelNodes; i++)
            {
                var currNode = queue.Dequeue();

                if (currNode.Left is not null)
                    queue.Enqueue(currNode.Left);

                if (currNode.Right is not null)
                    queue.Enqueue(currNode.Right);

                Console.WriteLine(currNode.Value);
            }
        }
    }

    public void Dfs(BinaryNode<T> node)
    {
        // inorder, preorder, postorder is a kind of DFS
    }

    #endregion Search

    #region Traversals

    public void Preorder(BinaryNode<T> node, List<T> path)
    {
        if (node is null)
            return;

        path.Add(node.Value);
        Preorder(node.Left, path);
        Preorder(node.Right, path);
    }

    public void Inorder(BinaryNode<T> node, List<T> path)
    {
        if (node is null)
            return;

        Inorder(node.Left, path);
        path.Add(node.Value);
        Inorder(node.Right, path);
    }

    public void Postorder(BinaryNode<T> node, List<T> path)
    {
        Postorder(node.Left, path);
        Postorder(node.Right, path);
        path.Add(node.Value);
    }

    #endregion Traversals
}

public class BinaryNode<T>
{
    public T Value { get; set; }
    public BinaryNode<T> Left { get; set; }
    public BinaryNode<T> Right { get; set; }

    public BinaryNode(T value)
    {
        Value = value;
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public List<Node<T>> Children { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}