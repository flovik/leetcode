using Sandbox.Solutions.Medium;

namespace Sandbox.Solutions.Hard;

public class WordSearch2
{
    private readonly TrieLetter _root = new('-');

    public IList<string> FindWords(char[][] board, string[] words)
    {
        // initialize Trie with words
        var temp = _root;

        foreach (var word in words)
        {
            foreach (var letter in word.ToCharArray())
            {
                temp = temp.ContainsLetter(letter) ? temp.GetLetter(letter) : temp.AddLetter(letter);
            }

            temp.IsWord = true;
            temp = _root;
        }

        var res = new List<string>();

        // find words in matrix by using trie prefix tree
        // repeating words are not taken into consideration
        // sequentially adjacent cells, the same letter cell may not be used more than once in a word
        for (var i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                BacktrackWordSearch("", _root, i, j, board, res);
            }
        }

        return res;
    }

    private void BacktrackWordSearch(string word, TrieLetter root, int x, int y, IReadOnlyList<char[]> board, IList<string> res)
    {
        // consider edge cases
        // skip out-of-bounds
        // skip already visited letters
        var letter = board[x][y];

        // check if root has the current letter in its Letter children
        if (letter == '-' || !root.ContainsLetter(letter))
            return;

        // see if that's a word
        var trieLetter = root.GetLetter(letter);
        if (trieLetter.IsWord)
        {
            res.Add(word + letter);
            trieLetter.IsWord = false; // de-duplicate
        }

        // mark as visited
        board[x][y] = '-';

        // go into four different directions
        if (x > 0)
            BacktrackWordSearch(word + letter, trieLetter, x - 1, y, board, res);

        if (y > 0)
            BacktrackWordSearch(word + letter, trieLetter, x, y - 1, board, res);

        if (x < board.Count - 1)
            BacktrackWordSearch(word + letter, trieLetter, x + 1, y, board, res);

        if (y < board[0].Length - 1)
            BacktrackWordSearch(word + letter, trieLetter, x, y + 1, board, res);

        // mark as unvisited after returning from recursion
        board[x][y] = letter;
    }

    private class TrieLetter
    {
        public TrieLetter(char letter)
        {
            Letter = letter;
            TrieLetters = new TrieLetter[26];
        }

        private char Letter { get; }
        private TrieLetter[] TrieLetters { get; }
        public bool IsWord { get; set; }

        public bool ContainsLetter(char letter)
        {
            return TrieLetters[letter - 'a'] is not null && TrieLetters[letter - 'a'].Letter != '-';
        }

        public TrieLetter GetLetter(char letter)
        {
            return TrieLetters[letter - 'a'];
        }

        public TrieLetter AddLetter(char letter)
        {
            var newLetter = new TrieLetter(letter);
            TrieLetters[letter - 'a'] = newLetter;
            return newLetter;
        }
    }
}