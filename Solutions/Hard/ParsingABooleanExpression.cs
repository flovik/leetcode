namespace Sandbox.Solutions.Hard;

public class ParsingABooleanExpression
{
    public bool ParseBoolExpr(string expression)
    {
        return Parse(expression);
    }

    private bool Parse(string expression)
    {
        return expression[0] switch
        {
            't' => true,
            'f' => false,
            '&' => And(expression),
            '|' => Or(expression),
            '!' => Not(expression),
            _ => false
        };
    }

    private bool And(string expression)
    {
        var expressions = GetExpressions(expression[2..^1]);
        var result = true;

        foreach (var s in expressions)
        {
            result &= Parse(s);
        }

        return result;
    }

    private bool Not(string expression)
    {
        var exp = expression[2..^1];
        return !Parse(exp);
    }

    private bool Or(string expression)
    {
        var expressions = GetExpressions(expression[2..^1]);
        var result = false;

        foreach (var s in expressions)
        {
            result |= Parse(s);
        }

        return result;
    }

    private string[] GetExpressions(string expression)
    {
        var expressions = new List<string>();

        for (var i = 0; i < expression.Length; i++)
        {
            if (expression[i] == 't')
                expressions.Add("t");
            if (expression[i] == 'f')
                expressions.Add("f");
            if (expression[i] == '&' ||
                expression[i] == '|' ||
                expression[i] == '!')
            {
                var index = GetExpressionEndIndex(expression[i..]);
                expressions.Add(expression[i..(i + index + 1)]);
                i += index;
            }
        }

        return expressions.ToArray();
    }

    private int GetExpressionEndIndex(string expression)
    {
        var st = new Stack<char>();
        st.Push('(');

        for (var i = 2; i < expression.Length; i++)
        {
            if (expression[i] == '(')
                st.Push('(');

            if (expression[i] == ')')
                st.Pop();

            if (st.Count == 0)
                return i;
        }

        return expression.Length - 1;
    }
}