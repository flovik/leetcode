using System.Text;

namespace Sandbox.Solutions.Medium;

public class LongestPalindrome
{
    public string Sol(string s)
    {
        //compute only pairs of 2 and 3 length, because by expanding those will give all the necessary palindromes

        var answer = s[0].ToString();

        //compute 2 len pairs
        for (int i = 0; i < s.Length - 1; i++)
        {
            var pair = s.Substring(i, 2);
            if (IsPalindrome(pair))
            {
                //go to left and right of found palindrome and see if it can be enlarged
                var result = EnlargePalindrome(s, pair, i - 1, i + 2);
                if (result.Length > answer.Length) answer = result;
            }
        }

        //compute 3 len pairs
        for (int i = 0; i < s.Length - 2; i++)
        {
            var pair = s.Substring(i, 3);
            if (IsPalindrome(pair))
            {
                //go to left and right of found palindrome and see if it can be enlarged
                var result = EnlargePalindrome(s, pair, i - 1, i + 3);
                if (result.Length > answer.Length) answer = result;
            }
        }


        return answer;
    }

    private bool IsPalindrome(string input)
    {
        for (int i = 0, j = input.Length - 1; i < j; i++, j--)
        {
            if (input[i] != input[j]) return false;
        }

        return true;
    }

    private string EnlargePalindrome(string input, string palindrome, int i, int j)
    {
        var result = new StringBuilder(palindrome);

        while (i >= 0 && j < input.Length)
        {
            if (input[i] != input[j]) break;
            result.Append(input[i]);
            result.Insert(0, input[i]);
            i--;
            j++;
        }

        return result.ToString();
    }
}