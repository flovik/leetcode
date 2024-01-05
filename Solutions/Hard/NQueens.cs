namespace Sandbox.Solutions.Hard;

public class NQueens
{
    private readonly IList<IList<string>> _result = new List<IList<string>>(100);

    public IList<IList<string>> SolveNQueens(int n)
    {
        var board = new char[n][];

        // prep board
        for (var i = 0; i < n; i++)
        {
            var row = new char[n];
            for (var j = 0; j < n; j++)
                row[j] = '.';

            board[i] = row;
        }

        var freeColumns = new HashSet<int>(n);

        for (var i = 0; i < n; i++)
            freeColumns.Add(i);

        BacktrackQueens(board, 0, freeColumns);
        return _result;
    }

    // every queen should be placed on a different column and on a different row and different diagonal
    private void BacktrackQueens(char[][] board, int height, ISet<int> freeColumns)
    {
        // all queens were placed successfully
        if (height == board.Length)
        {
            var list = new List<string>(board.Length);
            list.AddRange(board.Select(row => new string(row)));
            _result.Add(list);
            return;
        }

        for (var i = 0; i < board.Length; i++)
        {
            // see if we can place queen here
            // 1. if not occupied column
            // 2. outer bounds of array
            // 3. upper queen is not placed close to the current queen
            if (freeColumns.Contains(i) &&
                // first row can be used freely
                (height == 0 || NoQueenNearby(board, i, height)))
            {
                board[height][i] = 'Q';
                freeColumns.Remove(i);
                BacktrackQueens(board, height + 1, freeColumns);
                freeColumns.Add(i);
                board[height][i] = '.';
            }
        }
    }

    private bool NoQueenNearby(char[][] board, int column, int row)
    {
        var upperRow = board[row - 1];

        // check col
        if (upperRow[column] == 'Q')
            return false;

        // check left diagonal
        for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i][j] == 'Q')
                return false;
        }

        // check right diagonal
        for (int i = row, j = column; i >= 0 && j < board.Length; i--, j++)
        {
            if (board[i][j] == 'Q')
                return false;
        }

        return true;
    }
}