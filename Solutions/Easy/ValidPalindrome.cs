namespace Sandbox.Solutions.Easy;

public class ValidPalindrome
{
    public bool IsPalindrome(string s)
    {
        // two pointers
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            // i goes forward, j stays at the same place, so move j back
            if (char.IsWhiteSpace(s[i]) || !char.IsLetterOrDigit(s[i]))
            {
                j++;
                continue;
            }

            if (char.IsWhiteSpace(s[j]) || !char.IsLetterOrDigit(s[j]))
            {
                i--;
                continue;
            }

            if (!char.ToLower(s[i]).Equals(char.ToLower(s[j])))
                return false;
        }
        return true;
    }
}