namespace Sandbox.Solutions.Medium;

public class Trie
{
    private readonly LetterNode _root = new('-');

    public Trie()
    {
        // tree data structure used to efficiently store and retrieve keys in a dataset of strings
        // autocomplete, spellchecker

        // n-ary tree data structure
    }

    public void Insert(string word)
    {
        var temp = _root;

        // insert the string into trie
        foreach (var letter in word)
        {
            if (temp.ContainsLetter(letter))
            {
                var nextLetter = temp.GetLetterNode(letter);
                temp = nextLetter;
                continue;
            }

            var nextNode = temp.InsertLetter(letter);
            temp = nextNode;
        }

        temp.SetIsWord();
    }

    public bool Search(string word)
    {
        var temp = _root;

        // return true if the string word is on the trie (if was inserted before)
        var allLettersMatchTrie = word.All(letter =>
        {
            var letterNode = temp.GetLetterNode(letter);

            if (letterNode is null)
                return false;

            temp = letterNode;
            return true;
        });

        return allLettersMatchTrie && temp.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        var temp = _root;

        // true if previously inserted string word that has the prefix, and false otherwise
        return prefix.All(letter =>
        {
            var letterNode = temp.GetLetterNode(letter);

            if (letterNode is null)
                return false;

            temp = letterNode;
            return true;
        });
    }

    private class LetterNode
    {
        public char Letter { get; set; }
        private Dictionary<char, LetterNode> NextLetters { get; }
        public bool IsWord { get; private set; }

        public LetterNode(char letter)
        {
            Letter = letter;
            NextLetters = new Dictionary<char, LetterNode>();
        }

        public LetterNode InsertLetter(char letter)
        {
            var letterNode = new LetterNode(letter);
            NextLetters.Add(letter, letterNode);
            return letterNode;
        }

        public bool ContainsLetter(char letter)
        {
            return NextLetters.ContainsKey(letter);
        }

        public LetterNode? GetLetterNode(char letter)
        {
            NextLetters.TryGetValue(letter, out var node);
            return node ?? null;
        }

        public void SetIsWord() => IsWord = true;
    }
}