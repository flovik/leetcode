namespace Sandbox.Solutions.Medium;

public class CountOfSubstringsContainingEveryVowelAndKConsonants2
{
    public long CountOfSubstrings(string word, int k)
    {
        long count = 0;
        var vowels = new int[5];

        // total number of substrings that contain every vowel at least once and exactly K consonants
        int left = 0, right = 0, curSum = 0, prefixVowels = 0;

        // at least (k + 1) - at least (k) = exactly k

        while (right < word.Length)
        {
            // increase count
            var index = GetVowelIndex(word[right]);

            if (index != -1) vowels[index]++;
            else curSum++;

            // new exactly K window should be found
            while (left < right && curSum > k)
            {
                prefixVowels = 0;

                var leftVowelIndex = GetVowelIndex(word[left]);

                if (leftVowelIndex != -1) vowels[leftVowelIndex]--;
                else curSum--;

                left++;
            }

            // satisfies condition
            if (vowels.All(e => e > 0) && curSum == k)
            {
                var leftVowelIndex = GetVowelIndex(word[left]);

                // calculate prefix vowels that can be included as substrings
                while (leftVowelIndex != -1 && vowels[leftVowelIndex] > 1)
                {
                    prefixVowels++;
                    vowels[leftVowelIndex]--;

                    left++;
                    leftVowelIndex = GetVowelIndex(word[left]);
                }

                count += 1 + prefixVowels;
            }

            right++;
        }

        return count;
    }

    private int GetVowelIndex(char c)
    {
        return c switch
        {
            'a' => 0,
            'e' => 1,
            'i' => 2,
            'o' => 3,
            'u' => 4,
            _ => -1
        };
    }
}