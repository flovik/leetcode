namespace Sandbox.Solutions.Medium;
public static class StringExtension
{
    public static int ToInt(this string str)
    {
        return int.Parse(str);
    }
}

public class EvaluateReversePolishNotation
{
    private readonly Stack<string> stack = new();
    private const string ADD = "+";
    private const string SUB = "-";
    private const string DIV = "/";
    private const string MUL = "*";
    public int EvalRPN(string[] tokens)
    {
        int answer = 0;

        foreach (var token in tokens)
        {
            int rightValue;
            int newValue;
            switch (token)
            {
                case ADD:
                    rightValue = stack.Pop().ToInt();
                    newValue = stack.Pop().ToInt() + rightValue;
                    stack.Push(newValue.ToString());
                    break;
                case SUB:
                    rightValue = stack.Pop().ToInt();
                    newValue = stack.Pop().ToInt() - rightValue;
                    stack.Push(newValue.ToString());
                    break;
                case DIV:
                    rightValue = stack.Pop().ToInt();
                    newValue = stack.Pop().ToInt() / rightValue;
                    stack.Push(newValue.ToString());
                    break;
                case MUL:
                    rightValue = stack.Pop().ToInt();
                    newValue = stack.Pop().ToInt() * rightValue;
                    stack.Push(newValue.ToString());
                    break;
                default:
                    stack.Push(token);
                    break;
            }
        }

        return stack.Pop().ToInt();
    }
}