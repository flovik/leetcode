using System.Text;

namespace Sandbox.Solutions.Medium;

public class RemoveAllAdjacentDuplicatesInStringII
{
    public string RemoveDuplicates(string s, int k)
    {
        var st = new Stack<(char, int)>(100);

        foreach (var ch in s)
        {
            if (st.Count == 0)
            {
                st.Push((ch, 1));
                continue;
            }

            if (st.TryPeek(out var pair))
            {
                if (pair.Item1 == ch)
                {
                    st.Pop();
                    st.Push((pair.Item1, pair.Item2 + 1));
                }
                else st.Push((ch, 1));
            }

            if (st.TryPeek(out var p) && p.Item2 == k)
                st.Pop();
        }


        var sb = new StringBuilder();
        foreach (var (ch, num) in st.Reverse().ToArray())
        {
            sb.Append(string.Concat(Enumerable.Repeat(ch, num)));
        }

        return sb.ToString();
    }
}