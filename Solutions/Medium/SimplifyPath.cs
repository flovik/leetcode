using System.Text;

namespace Sandbox.Solutions.Medium;

public class SimplifyPath
{
    public string SimplifyPathSol(string path)
    {
        var st = new Stack<string>();
        var tokens = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var token in tokens)
        {
            if (token.Equals(".."))
            {
                if (st.Count < 2)
                    continue;

                st.Pop();
                st.Pop();
            }
            else if (!token.Equals("."))
            {
                st.Push("/");
                st.Push(token);
            }
        }

        if (st.Count == 0)
            return "/";

        return st.ToArray().Aggregate("", (s, s1) => s1 + s);
    }
}