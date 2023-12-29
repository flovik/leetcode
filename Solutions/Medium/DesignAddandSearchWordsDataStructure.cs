namespace Sandbox.Solutions.Medium;

public class WordDictionary
{
    private readonly TrieLetter _root = new('-');

    public WordDictionary()
    {
    }

    public void AddWord(string word)
    {
        var temp = _root;
        foreach (var letter in word)
        {
            if (temp.ContainsLetter(letter))
            {
                temp = temp.GetLetter(letter);
                continue;
            }

            temp = temp.AddLetter(letter);
        }

        temp.IsWord = true;
    }

    public bool Search(string word)
    {
        // where we have dots, take every letter and search if it has the next letter in its sequence
        // by constraint, will have max to 2 dots
        // for each NextLetter in letter TrieLetter, search if any from all of them contains the searched sequence
        return Search(word, _root);
    }

    private bool Search(string word, TrieLetter root)
    {
        var temp = root;

        for (int i = 0; i < word.Length; i++)
        {
            // if letter is a dot
            if (word[i] == '.')
            {
                var remainingWord = word[(i + 1)..];
                var possibleLetters = temp.GetLetters();

                return possibleLetters.Any(letter => Search(remainingWord, letter));
            }

            if (!temp.ContainsLetter(word[i]))
                return false;

            temp = temp.GetLetter(word[i]);
        }

        return temp.IsWord;
    }

    private class TrieLetter
    {
        private char Letter { get; set; } = '-';
        private TrieLetter[] NextLetters { get; set; } = new TrieLetter[26];
        public bool IsWord { get; set; }

        public TrieLetter(char letter)
        {
            Letter = letter;
        }

        public TrieLetter AddLetter(char letter)
        {
            var newLetter = new TrieLetter(letter);
            NextLetters[letter - 97] = newLetter;
            return newLetter;
        }

        public TrieLetter? GetLetter(char letter)
        {
            if (NextLetters[letter - 97] is null)
                return null;

            var trieLetter = NextLetters[letter - 97];
            return trieLetter.Letter != '-' ? trieLetter : null;
        }

        public bool ContainsLetter(char letter)
        {
            if (NextLetters[letter - 97] is null)
                return false;

            var trieLetter = NextLetters[letter - 97];
            return trieLetter.Letter != '-';
        }

        public TrieLetter[] GetLetters()
        {
            return NextLetters.Where(l => l is not null).ToArray();
        }
    }
}