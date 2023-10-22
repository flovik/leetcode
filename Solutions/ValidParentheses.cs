namespace Sandbox.Solutions;

public class ValidParentheses
{
    private readonly Stack<char> st = new();
    public bool IsValid(string s)
    {
        foreach (var character in s)
        {
            if (st.TryPeek(out char res))
            {
                switch (res)
                {
                    case '(' when character == ')':
                        st.Pop();
                        break;
                    case '{' when character == '}':
                        st.Pop();
                        break;
                    case '[' when character == ']':
                        st.Pop();
                        break;
                    default:
                        st.Push(character);
                        break;
                }
            }
            else st.Push(character);
        }

        return st.Count == 0;
    }
}