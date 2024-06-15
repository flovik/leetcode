namespace Sandbox.Topics.Trie;

public class TrieStructure
{
    private LetterNode _head;

    public TrieStructure()
    {
        _head = new LetterNode();
        // Console.WriteLine('a' - 97);
    }

    public void Insert(string word)
    {
        var temp = _head;

        foreach (var letter in word)
        {
            if (temp.NextLetters[letter - 97] is null)
            {
                var newLetter = new LetterNode(letter);
                temp.NextLetters[letter - 97] = newLetter;
            }

            temp = temp.NextLetters[letter - 97];
        }

        temp.IsWord = true;
    }

    public bool Search(string word)
    {
        var temp = _head;

        foreach (var letter in word)
        {
            if (temp.NextLetters[letter - 97] is null)
                return false;

            temp = temp.NextLetters[letter - 97];
        }

        return temp.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        var temp = _head;

        foreach (var letter in prefix)
        {
            if (temp.NextLetters[letter - 97] is null)
                return false;

            temp = temp.NextLetters[letter - 97];
        }

        return true;
    }
}

public class LetterNode
{
    public char Letter { get; set; }
    public LetterNode[] NextLetters { get; set; } = new LetterNode[26];
    public bool IsWord { get; set; }

    public LetterNode()
    { }

    public LetterNode(char letter)
    {
        Letter = letter;
    }
}