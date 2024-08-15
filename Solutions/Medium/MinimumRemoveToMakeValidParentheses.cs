using System.Text;

namespace Sandbox.Solutions.Medium;

public class MinimumRemoveToMakeValidParentheses
{
    public string MinRemoveToMakeValid(string s)
    {
        var sb = new StringBuilder(s.Length);
        // openClose keeps track of matching open parenthesis to close ones
        int openClose = 0, closed = 0;

        closed += s.Count(t => t == ')');

        foreach (var c in s)
        {
            switch (c)
            {
                case '(' when openClose == closed: // already matched, ignore
                    continue;
                case '(':
                    openClose++; // then we have closed parenthesis that can match with (
                    break;

                case ')':
                    closed--;
                    if (openClose == 0) // if no matching, skip
                        continue;

                    openClose--;
                    break;
            }

            sb.Append(c);
        }

        return sb.ToString();
    }

    public string MinRemoveToMakeValidStack(string s)
    {
        var st = new Stack<(char, int)>(s.Length);
        var sb = new StringBuilder(s.Length);

        for (var i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case ')':
                    if (st.Count > 0 && st.Peek().Item1 == '(')
                        st.Pop();
                    else
                        st.Push((')', i));
                    break;

                case '(':
                    st.Push(('(', i));
                    break;

                default:
                    continue;
            }
        }

        // if stack has un-processed parentheses, ignore them
        var set = new HashSet<int>(st.Select(e => e.Item2));

        for (int i = 0; i < s.Length; i++)
        {
            if (set.Contains(i))
                continue;

            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}