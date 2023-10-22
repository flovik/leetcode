using System.Text;

namespace Sandbox.Solutions.Easy;

public class MakeTheStringGood
{
    public string MakeGood(string s)
    {
        var stack = new Stack<char>();
        var result = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if(stack.Count == 0) stack.Push(s[i]);
            else
            {
                if (string.Equals(stack.Peek().ToString(), s[i].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if((char.IsLower(stack.Peek()) && char.IsUpper(s[i])) || 
                        (char.IsUpper(stack.Peek()) && char.IsLower(s[i])))
                        stack.Pop();
                    else stack.Push(s[i]);
                }
                else stack.Push(s[i]);
            }
        }

        while (stack.Count != 0)
        {
            result.Insert(0, stack.Pop());
        }

        return result.ToString();
    }
}