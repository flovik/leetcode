namespace Sandbox.Solutions.Hard;

public class MinimumWindowSubstring
{
    private readonly Dictionary<char, int> _occurrencesDictionary = new();

    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length || s.Length == 0)
            return "";

        // save occurrences of t in dictionary and like in the Permutation problem with sliding window
        foreach (var character in t)
        {
            AddDictionary(_occurrencesDictionary, character);
        }

        // keep count of the NEEDED characters (in t)
        int start = 0, end = 0, maxCount = 0, minLength = s.Length + 1, minLeft = 0;

        // slide the window one by one and when maxCount > t.Length (duplicates are also included)
        // when a substring found (shrink it from left to right in case it is not the smallest one), needed characters will be on the sides of the substring
        // slide start to the next needed character and search for the next smallest substring
        while (end < s.Length)
        {
            // if the end is the needed 
            if (_occurrencesDictionary.ContainsKey(s[end]))
            {
                _occurrencesDictionary[s[end]]--;

                // if the needed go to negative, don't increase maxCount anymore
                if (_occurrencesDictionary[s[end]] >= 0)
                {
                    maxCount++;
                }

                // the necessary number of characters are 
                while (maxCount == t.Length)
                {
                    // if a new minimum substring was found
                    if (end - start + 1 < minLength)
                    {
                        minLeft = start;
                        minLength = end - start + 1;
                    }

                    // start is slid to the next needed character encountered on the way
                    if (_occurrencesDictionary.ContainsKey(s[start]))
                    {
                        _occurrencesDictionary[s[start]]++;

                        // but if the removed needed character is a mandatory one, the while loop will stop
                        if (_occurrencesDictionary[s[start]] > 0)
                            maxCount--;
                    }

                    start++;
                }
            }

            end++;
        }

        return minLength > s.Length ? "" : s.Substring(minLeft, minLength);

        void AddDictionary(IDictionary<char, int> dict, char c)
        {
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict.Add(c, 1);
        }
    }
}