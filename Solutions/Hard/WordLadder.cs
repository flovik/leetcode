namespace Sandbox.Solutions.Hard;

public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var setWords = wordList.ToHashSet();

        if (!setWords.Contains(endWord))
            return 0;

        // starting word is also in the sequence
        var resultCount = 1;

        var queue = new Queue<string>();
        queue.Enqueue(beginWord);

        // to not repeat the words in queue, keep a visited array for words that have already been in queue
        var visited = new HashSet<string>();

        // BFS to the solution, remove a word from set if it is existent
        // each word that can be created from beginWord and go letter by letter
        // e.g. hit -> hot, hog
        // we have hot -> hit, dot, hog
        // check if any of those words are in set, add them to queue and delete current word from set to not search it anymore
        while (queue.Count != 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var currentWord = queue.Dequeue();

                if (currentWord == endWord)
                    return resultCount;

                for (var j = 0; j < currentWord.Length; j++)
                {
                    for (var k = 'a'; k <= 'z'; k++)
                    {
                        var possibleWord = currentWord.ToCharArray();
                        possibleWord[j] = k; // substitute char at specified index with all possible characters and add the found word

                        var strPossibleWord = new string(possibleWord);
                        if (setWords.Contains(strPossibleWord) && !visited.Contains(strPossibleWord))
                        {
                            queue.Enqueue(strPossibleWord);
                            visited.Add(strPossibleWord);
                        }
                    }
                }

                setWords.Remove(currentWord);
            }

            resultCount++;
        }

        return 0;
    }
}