using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class MinimumNumberOfSwapsToMakeTheStringBalanced
{
    public int MinSwaps(string s)
    {
        // even length
        var str = s.ToCharArray();
        int close = 0, result = 0;
        var st = new Stack<int>(s.Length);

        int left = 0, right = s.Length - 1;
        while (left < s.Length)
        {
            if (str[left] == '[')
            {
                st.Push(str[left]);
                left++;
            }
            else if (str[left] == ']' && st.TryPeek(out var ch) && ch == '[')
            {
                st.Pop();
                left++;
            }
            else
            {
                // count closing brackets and when it becomes -1, swap with current str[left]
                while (close != -1 && left < right)
                {
                    close = str[right] == ']' ? close + 1 : close - 1;

                    if (close != -1)
                        right--;
                }

                (str[left], str[right]) = (str[right], str[left]);
                result++;
                right--;
                close = 0;
            }
        }

        return result;
    }
}