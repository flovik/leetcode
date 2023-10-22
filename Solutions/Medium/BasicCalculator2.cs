using System.Text.RegularExpressions;

namespace Sandbox.Solutions.Medium;

public class BasicCalculator2
{
    Regex number = new (@"[\d]");
    public int Calculate(string s)
    {
        var stack = new Stack<string>();

        //spaces, + and - are ignored
        for (int i = 0; i < s.Length; i++)
        {
            //if digit
            if (number.IsMatch(s[i].ToString()))
            {
                var res = FindNumber(s, i);

                stack.Push(s.Substring(i, res.Item3 - i + 1));
                i = res.Item3;

            }
            else if (s[i] == '*')
            {
                var stackNumber = stack.Pop();
                int number = int.Parse(stackNumber);
                var res = FindNumber(s, ++i);
                int number2 = int.Parse(res.Item1);
                i = res.Item3;

                number *= number2;
                stack.Push(number.ToString());
            }
            else if (s[i] == '/')
            {
                var stackNumber = stack.Pop();
                int number = int.Parse(stackNumber);
                var res = FindNumber(s, ++i);
                int number2 = int.Parse(res.Item1);
                i = res.Item3;

                number /= number2;
                stack.Push(number.ToString());
            }
            else if (s[i] == '+') stack.Push(s[i].ToString());
            else if (s[i] == '-')
            {
                stack.Push("+");
                var number = FindNumber(s, ++i);;
                i = number.Item3;

                stack.Push("-" + number.Item1);
            }
        }

        //perform + and - operations
        while (stack.Count != 1)
        {
            int number = int.Parse(stack.Pop());
            stack.Pop(); //pop the sign, always a plus
            int number2 = int.Parse(stack.Pop());
            number2 += number;
            stack.Push(number2.ToString());
        }

        return int.Parse(stack.Pop());
    }

    //returns the number in string, first int is the start of number, second is the finish of number
    private (string, int, int) FindNumber(string s, int i)
    {
        while (s[i] == ' ')
        {
            i++;
        }

        string result;
        int j = i;
        while (true)
        {
            if (j == s.Length - 1) break;
            if (!number.IsMatch(s[j + 1].ToString())) break;
            j++;
        }

        result = s.Substring(i, j - i + 1);
        return (result, i, j);
    }
}