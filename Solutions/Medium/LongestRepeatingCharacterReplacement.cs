namespace Sandbox.Solutions.Medium;

internal class LongestRepeatingCharacterReplacement
{
    private readonly Dictionary<char, int> _dictionary = new();

    public int CharacterReplacement(string s, int k)
    {
        int start = 0, end = 0, maxCount = 0, maxLength = 0;

        while (end < s.Length)
        {
            // keep track of the popularity of each letter in the window
            if (_dictionary.ContainsKey(s[end]))
                _dictionary[s[end]]++;
            else
                _dictionary.Add(s[end], 1);

            // maxCount keeps track of the most popular character that we've passed in the window
            // on each iteration we pass every character in the dictionary, so it's safe to make that check
            maxCount = Math.Max(maxCount, _dictionary[s[end]]);

            // we have more characters than [(len of substring) - (count of most popular character) = k], move the start pointer forward
            while (end - start + 1 - maxCount > k)
            {
                _dictionary[s[start]]--;
                start++;
            }

            // end - start + 1 is already the optimal window that we have so far and it is controlled by the while loop above
            maxLength = Math.Max(end - start + 1, maxLength);
            end++;
        }

        return maxLength;
    }

    // expand window until it's not a valid window anymore
    // move right pointer to the right, one by one, until (len of substring) - (count of most popular character) = k
    // track most popular character with maxCount, when we see it - increment and check if greater

    // we have a window from i to j, and maxCount + k characters. Here we slide the window to the right. Because
    // the window represents our best answer so fa, it doesn't make sense to shrink the window. When we move the entire window
    // we see a new character at the end, and add that to the count array, and also decrement the count of the character at the start, which is out of the window

    // now we need to know if the total count of the new character at end is greater than our maxCount (which is the most popular count for the CURRENT WINDOW SIZE that we've seen)
    // if any character exceeds maxCount: we have a bigger window and a new maxCount. Every step you move j pointer to the right, if you can slide the window without
    // violating the rules - do it, if not then slide the i pointer forward
    // size of the window = the value we a re trying to find the biggest value for

    /*
     * "I have a window of length 4, where 2 of the characters were the same (the maxCount characters).
     * Can I find any other window with the same length, but more characters that are the same?
     * If so, then I can expand my window and I've found a larger window.
     * Save this window length as my current best answer. Now repeat until I get to the end. Then return the largest window I saw in this string."
     */
}