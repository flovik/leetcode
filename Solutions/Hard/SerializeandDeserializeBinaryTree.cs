using System.Text;
using Sandbox.DataStructures;

namespace Sandbox.Solutions.Hard;

public class SerializeandDeserializeBinaryTree
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root is null)
            return "[]";

        var sb = new StringBuilder("[");
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        sb.Append($"{root.val},");

        while (queue.Count != 0)
        {
            var nodesInLevel = queue.Count;
            var levelSb = new StringBuilder();
            var nullableLevel = true;

            while (nodesInLevel > 0)
            {
                var node = queue.Dequeue();

                if (node.left is not null)
                {
                    queue.Enqueue(node.left);
                    levelSb.Append($"{node.left.val},");
                    nullableLevel = false;
                }
                else
                    levelSb.Append("null,");

                if (node.right is not null)
                {
                    queue.Enqueue(node.right);
                    levelSb.Append($"{node.right.val},");
                    nullableLevel = false;
                }
                else
                    levelSb.Append("null,");

                nodesInLevel--;
            }

            // if queue is not empty, then append the sb to the original sb
            if (!nullableLevel)
                sb.Append(levelSb);
        }

        // remove the last comma
        sb.Remove(sb.Length - 1, 1);
        sb.Append(']');

        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        // [1,2,3,null,null,4,5]
        var nodesToSkip = 1;
        var tokens = data[1..^1].Split(',');

        if (tokens.Length == 1 && string.IsNullOrEmpty(tokens[0]))
            return null;

        var root = new TreeNode(int.Parse(tokens[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        for (int i = 0; i < tokens.Length / 2; i++)
        {
            var nodeLeftValue = tokens[i + nodesToSkip];
            var nodeRightValue = tokens[i + nodesToSkip + 1];
            var rootNode = queue.Dequeue();

            if (nodeLeftValue != "null")
            {
                var leftNode = new TreeNode(int.Parse(nodeLeftValue));
                rootNode.left = leftNode;
                queue.Enqueue(leftNode);
            }

            if (nodeRightValue != "null")
            {
                var rightNode = new TreeNode(int.Parse(nodeRightValue));
                rootNode.right = rightNode;
                queue.Enqueue(rightNode);
            }

            nodesToSkip++;
        }

        return root;
    }
}