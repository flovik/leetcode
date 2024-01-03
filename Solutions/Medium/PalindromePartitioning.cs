namespace Sandbox.Solutions.Medium;

public class PalindromePartitioning
{
    private IList<IList<string>> _result = new List<IList<string>>(140);

    public IList<IList<string>> Partition(string s)
    {
        // each partition that is a palindrome
        BacktrackPartitioning(new List<string>(s.Length), s, "");
        return _result;
    }

    private void BacktrackPartitioning(IList<string> current, string word, string currentPartition)
    {
        if (word.Length == 0)
        {
            _result.Add(new List<string>(current));
            return;
        }

        // search the whole substring from (start)
        // Backtrack will call subsequent substrings of the word (from i = 1, 2, etc.)
        for (int i = 0; i < word.Length; i++)
        {
            currentPartition += word[i];
            // if found substring in the current for, send the Backtrack partitioning
            if (IsPalindrome(currentPartition))
            {
                current.Add(currentPartition);
                BacktrackPartitioning(current, word[(i + 1)..], "");
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s)
    {
        // two pointers
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j])
                return false;
        }

        return true;
    }
}