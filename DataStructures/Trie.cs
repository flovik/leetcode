namespace Sandbox.DataStructures;

public class Trie
{
    private TrieNode? _root;

    public Trie()
    {
        // Initializes the trie object.
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        // Inserts the string word into the trie.
        var temp = _root;

        foreach (var letter in word)
        {
            if (!temp.IsPresent(letter))
            {
                temp.SetTrieNode(letter);
            }

            temp = temp.GetTrieNode(letter);
        }

        temp.SetWord();
    }

    public bool Search(string word)
    {
        // Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
        var node = SearchPrefix(word);
        return node is not null && node.IsWord();
    }

    public bool StartsWith(string prefix)
    {
        // Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.s
        var node = SearchPrefix(prefix);
        return node is not null;
    }

    private TrieNode? SearchPrefix(string word)
    {
        // two cases which return false
        // there are more characters left, but cannot move forward and isWord is false
        // no more characters and isWord is false, therefore the search key is only a prefix of another key
        var node = _root;

        foreach (var letter in word)
        {
            if (node.IsPresent(letter)) node = node.GetTrieNode(letter); // next char
            else return null;
        }

        return node;
    }
}

public class TrieNode
{
    private readonly TrieNode?[] _children;
    private bool _IsWord;

    public TrieNode()
    {
        _children = new TrieNode[26];
    }

    public TrieNode? GetTrieNode(char character)
    {
        return _children[character - 'a'];
    }

    public void SetTrieNode(char character)
    {
        _children[character - 'a'] = new TrieNode();
    }

    public bool IsPresent(char character)
    {
        return _children[character - 'a'] is not null;
    }

    public bool IsWord()
    {
        return _IsWord;
    }

    public void SetWord()
    {
        _IsWord = true;
    }
}