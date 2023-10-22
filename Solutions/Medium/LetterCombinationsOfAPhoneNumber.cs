using System.Text;

namespace Sandbox.Solutions.Medium;

public class LetterCombinationsOfAPhoneNumber
{
    private readonly IDictionary<char, string> _letterCombinations = new Dictionary<char, string>
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"},
        
    };

    private IList<string> result = new List<string>();

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length > 0) AppendLetter("", digits);
        return result;
    }

    private void AppendLetter(string currentCombination, string digits)
    {
        //if no more letters to add, add to the end result
        if (digits.Length == 0)
        {
            result.Add(currentCombination);
            return;
        }

        //for each letter in current letter, add its letter to the final combination and remove the letter
        foreach (var letter in _letterCombinations[digits[0]])
        {
            AppendLetter(currentCombination + letter, digits[1..]);
        }
    }

    public IList<string> LetterCombinations(StringBuilder digits)
    {
        if (digits.Length != 0)
        {
            foreach (var letter in _letterCombinations[digits[0]])
            {
                result.Add(letter.ToString());
            }

            for (int i = 1; i < digits.Length; i++)
            {
                var temp = new List<string>();
                foreach (var combination in result)
                {
                    foreach (var letter in _letterCombinations[digits[i]])
                    {
                        temp.Add(combination + letter);
                    }
                }

                result = temp;
            }
        }

        return result;
    }
}