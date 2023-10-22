using System.Collections;
using System.Text;

namespace Sandbox.Solutions.Medium;

public class GenerateParanthesesAnotherTry
{
    public const string OpenP = "(";
    public const string CloseP = ")";
    public IList<string> GenerateParenthesis(int n)
    {
        var stringBuilder = new StringBuilder(n * 2);
        var result = new List<string>();
        BacktrackSolution(stringBuilder, n, 0, 0, result);
        return result;
    }

    private void BacktrackSolution(StringBuilder stringBuilder, int n, int left, int right,
        IList<string> result)
    {
        if (left == right && left == n)
        {
            result.Add(stringBuilder.ToString());
            return;
        }

        if (left < n)
        {
            BacktrackSolution(stringBuilder.Append(OpenP), n, left + 1, right, result);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }

        if (right < left)
        {
            BacktrackSolution(stringBuilder.Append(CloseP), n, left, right + 1, result);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }
    }
}