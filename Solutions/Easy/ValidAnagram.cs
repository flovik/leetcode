namespace Sandbox.Solutions.Easy;

public class ValidAnagram
{
    private IDictionary<char, int> charsOccurences = new Dictionary<char, int>();
    public bool IsAnagram(string s, string t)
    {
        foreach (var c in s)
        {
            if (charsOccurences.ContainsKey(c)) charsOccurences[c] += 1;
            else charsOccurences.Add(new KeyValuePair<char, int>(c, 1));
        }

        foreach (var c in t)
        {
            if (!charsOccurences.ContainsKey(c)) return false;

            if (charsOccurences[c] == 1) charsOccurences.Remove(c);
            else charsOccurences[c]--;
        }

        return charsOccurences.Count <= 0;
    }
}