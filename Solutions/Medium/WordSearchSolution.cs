namespace Sandbox.Solutions.Medium;

public class WordSearchSolution
{
    private char[][] _board;
    private bool _answer;

    public bool Exist(char[][] board, string word)
    {
        _board = board;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (_answer)
                    return _answer;

                _board = board;

                BacktrackWordSearch(word, i, j);
            }
        }
        return _answer;
    }

    private void BacktrackWordSearch(string word, int x, int y)
    {
        if (_answer)
            return;

        if (x < 0 || y < 0 || x > _board.Length - 1 || y > _board[0].Length - 1)
            return;

        if (_board[x][y] == '+')
            return;

        if (word[0] != _board[x][y])
            return;

        _board[x][y] = '+';

        if (word.Length == 1)
        {
            _answer = true;
            return;
        }

        BacktrackWordSearch(word[1..], x - 1, y);
        BacktrackWordSearch(word[1..], x + 1, y);
        BacktrackWordSearch(word[1..], x, y - 1);
        BacktrackWordSearch(word[1..], x, y + 1);

        _board[x][y] = word[0];
    }
}