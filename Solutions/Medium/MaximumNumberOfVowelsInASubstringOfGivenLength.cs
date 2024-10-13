namespace Sandbox.Solutions.Medium;

public class MaximumNumberOfVowelsInASubstringOfGivenLength
{
    public int MaxVowels(string s, int k)
    {
        int left = 0, right = 0, maxVowels = 0, vowels = 0;

        while (right < s.Length)
        {
            if (IsVowel(s[right]))
                vowels++;

            if (right - left >= k && IsVowel(s[left++]))
                vowels--;

            if (right - left + 1 == k)
                maxVowels = Math.Max(maxVowels, vowels);

            right++;
        }

        return maxVowels;
    }

    private static bool IsVowel(char a) => a is 'a' or 'e' or 'i' or 'o' or 'u';
}