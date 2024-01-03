namespace Sandbox.Solutions.Medium;

public class LetterCombinationsOfaPhoneNumberSolution
{
    private readonly Dictionary<char, string> _digitToLettersDictionary = new()
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

    private IList<string> _result = new List<string>(50);

    public IList<string> LetterCombinations(string digits)
    {
        if (digits == "")
            return _result;

        BacktrackLetterCombinations(digits, "");
        return _result;
    }

    private void BacktrackLetterCombinations(string digits, string currentCombination)
    {
        if (string.IsNullOrEmpty(digits))
        {
            _result.Add(currentCombination);
            return;
        }

        var letters = _digitToLettersDictionary[digits[0]];
        foreach (var letter in letters)
        {
            BacktrackLetterCombinations(digits[1..], currentCombination + letter);
        }
    }
}