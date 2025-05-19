using System.Text;

namespace Sandbox.Solutions.Medium;

public class AddingSpacesToAString
{
    public string AddSpaces(string s, int[] spaces)
    {
        var sb = new StringBuilder();

        int[] newSpaces = [0, .. spaces, s.Length];

        for (var i = 0; i < newSpaces.Length - 1; i++)
        {
            var len = newSpaces[i + 1] - newSpaces[i];
            var sp = s.AsSpan(newSpaces[i], len);

            sb.Append(sp);

            if (i < newSpaces.Length - 2)
                sb.Append(' ');
        }

        return sb.ToString();
    }
}