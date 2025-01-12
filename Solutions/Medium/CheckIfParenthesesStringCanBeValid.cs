using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class CheckIfParenthesesStringCanBeValid
{
    public bool CanBeValid(string s, string locked)
    {
        if (s.Length % 2 == 1)
            return false;

        int open = 0, closed = 0;

        // left-to-right - if too many ) -> not balanced
        for (int i = 0; i < s.Length; i++)
        {
            if (locked[i] == '0' || s[i] == '(')
                open++;
            else
                open--;

            if (open < 0)
                return false;
        }

        // right-to-left - if too many ( -> not balanced
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (locked[i] == '0' || s[i] == ')')
                closed++;
            else
                closed--;

            if (closed < 0)
                return false;
        }

        return true;
    }
}