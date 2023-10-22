using System.Text;

namespace Sandbox.Solutions.Medium;

public class WordSearch
{
    public bool Exist(char[][] board, string word)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (BFS(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool BFS(char[][] board, string word, int i, int j, int index)
    {
        if (word.Length == index) return true;
        if (i < 0 || j < 0 || j > board[0].Length - 1 || i > board.Length - 1) return false;
        if (word[index] != board[i][j]) return false;

        board[i][j] = '*';

        bool search = BFS(board, word, i - 1, j, index + 1) ||
                      BFS(board, word, i, j - 1, index + 1) ||
                      BFS(board, word, i, j + 1, index + 1) ||
                      BFS(board, word, i + 1, j, index + 1);

        board[i][j] = word[index];
        return search;
    }
}