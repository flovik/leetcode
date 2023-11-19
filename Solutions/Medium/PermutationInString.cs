namespace Sandbox.Solutions.Medium;

public class PermutationInString
{
    private readonly Dictionary<char, int> _charactersOccurrences = new();

    public bool CheckInclusion(string s1, string s2)
    {
        // find a substring in s2 that contains all the characters of s1
        // any substring that contains all the characters is automatically a permutation, so just return it
        foreach (var character in s1)
        {
            AddToDictionary(_charactersOccurrences, character);
        }

        // _charactersOccurrences will keep track of characters and how many they should be
        // trackingDictionary will keep track of the current characters in the substring
        var trackingDictionary = new Dictionary<char, int>();
        int start = 0, end = 0;

        var countNeededCharacters = 0;

        // slide the window in case we don't have enough characters to check if it is the right substring
        while (end < s2.Length)
        {
            var rightKey = s2[end];

            // if the window is starting to get bigger than substring
            if (end - start == s1.Length)
            {
                var leftKey = s2[start++];
                if (_charactersOccurrences.ContainsKey(leftKey))
                {
                    countNeededCharacters--;
                    trackingDictionary[leftKey]--;
                }
            }

            if (_charactersOccurrences.ContainsKey(rightKey))
            {
                countNeededCharacters++;
                AddToDictionary(trackingDictionary, rightKey);
            }

            end++;

            if (countNeededCharacters != s1.Length)
                continue;

            // we can have {A - 2} with {B - 1} with correct count, but in tracking only {A - 3}, so check that too
            if (_charactersOccurrences.All(x => trackingDictionary.ContainsKey(x.Key) && trackingDictionary[x.Key] == x.Value))
                return true;
        }

        return false;

        void AddToDictionary(IDictionary<char, int> dict, char character)
        {
            if (dict.ContainsKey(character))
                dict[character]++;
            else
                dict.Add(character, 1);
        }
    }
}