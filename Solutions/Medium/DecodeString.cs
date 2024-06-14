using System.Diagnostics.Metrics;
using System.Text;

namespace Sandbox.Solutions.Medium;

public class DecodeStringSol
{
    public string DecodeString(string s)
    {
        var stack = new Stack<string>(s.Length);
        var sb = new StringBuilder(10000);

        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsAsciiDigit(s[i]))
            {
                var start = i;
                while (char.IsAsciiDigit(s[i + 1]))
                    i += 1;

                stack.Push(s[start..(i + 1)]);
                stack.Push("");
            }
            else if (s[i] == ']')
            {
                var seq = stack.Pop();
                var times = stack.Pop();

                int.TryParse(times, out var count);

                var sbb = new StringBuilder(count);

                for (var j = 0; j < count; j++)
                {
                    sbb.Append(seq);
                }

                if (stack.Count == 0)
                    sb.Append(sbb);
                else
                    stack.Push(stack.Pop() + sbb);
            }
            else if (s[i] != '[')
            {
                if (stack.Count > 0)
                    stack.Push(stack.Pop() + s[i]);
                else
                    sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }
}