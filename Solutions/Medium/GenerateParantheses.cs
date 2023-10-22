using System.Text;

namespace Sandbox.Solutions.Medium;

public class GenerateParantheses
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        BacktrackSolution(result, new StringBuilder() ,0, 0, n);
        return result;
    }

    private void BacktrackSolution(IList<string> results, StringBuilder sb, int left, int right, int n)
    {
        if (left == n && right == n)
        {
            results.Add(sb.ToString());
            return;
        }

        if (left < n)
        {
            sb.Append("(");
            BacktrackSolution(results, sb, left + 1, right, n);
            sb.Length--;
        }

        if (right < left)
        {
            sb.Append(")");
            BacktrackSolution(results, sb, left, right + 1, n);
            sb.Length--;
        }
    }
}