namespace Sandbox.Solutions.Medium;

public class SearchSuggestionsSystem
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        // suggests at most three product names from products after each character of searchWord is typed
        // should have common prefix, if more than three, return three lexicographically minimum products
        // trie implementation

        var trie = new Trie();
        foreach (var product in products)
        {
            trie.AddWord(product);
        }

        var list = new List<IList<string>>(searchWord.Length);
        for (int i = 1; i <= searchWord.Length; i++)
        {
            // do a DFS on Letters and find first three IsWord = true
            var searchedProducts = trie.GetThreeProducts(searchWord[..i]);
            list.Add(searchedProducts);
        }

        return list;
    }

    private class Trie
    {
        private readonly LetterNode _root = new('-');

        public void AddWord(string word)
        {
            var cur = _root;
            foreach (var letter in word)
            {
                var nextLetter = cur.NextLetter[letter - 'a'] ?? new LetterNode(letter);
                cur.NextLetter[letter - 'a'] = nextLetter;
                cur = nextLetter;
            }

            cur.IsWord = true;
        }

        public IList<string> GetThreeProducts(string prefix) => GetProducts(prefix, []);

        private IList<string> GetProducts(string prefix, List<string> list)
        {
            var cur = _root;
            foreach (var letter in prefix)
            {
                var nextLetter = cur.NextLetter[letter - 'a'];
                if (nextLetter is null)
                    return [];

                cur = nextLetter;
            }

            if (cur is null)
                return list;

            // get first 3 IsWord words
            Dfs(cur, list, prefix[..^1]);
            return list;
        }

        private static void Dfs(LetterNode letter, List<string> list, string prefix)
        {
            if (letter.IsWord && list.Count < 3)
                list.Add(prefix + letter.Letter);

            if (list.Count == 3)
                return;

            for (var i = 0; i < 26; i++)
            {
                var nextLetter = letter.NextLetter[i];
                if (nextLetter is null)
                    continue;

                Dfs(nextLetter, list, prefix + letter.Letter);
            }
        }
    }

    private class LetterNode(char letter, bool isWord = false)
    {
        public char Letter { get; set; } = letter;

        public bool IsWord { get; set; } = isWord;

        public LetterNode?[] NextLetter { get; set; } = new LetterNode?[26]; // lowercase english letters
    }
}