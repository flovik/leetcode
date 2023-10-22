namespace Sandbox.Solutions.Medium;

public class ValidSudoku
{
    private ISet<char> numbersSet = new HashSet<char>();
    public bool IsValidSudoku(char[][] board)
    {

        // check each row (9 times)
        for (int i = 0; i < 9; i++)
        {
            if (!IsRowValid(board, i)) return false;
            numbersSet.Clear();
        }

        // check each column (9 times)
        for (int i = 0; i < 9; i++)
        {
            if (!IsColumnValid(board, i)) return false;
            numbersSet.Clear();
        }

        // check each box (9 times)
        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j += 3)
            {
                if (!IsBoxValid(board, i, j)) return false;
                numbersSet.Clear();
            }
        }

        return true;
    }

    private bool IsRowValid(char[][] board, int rowId)
    {
        for (int i = 0; i < board[rowId].Length; i++)
        {
            var value = board[rowId][i];
            if (value == '.') continue;
            if (numbersSet.Contains(value)) return false;

            numbersSet.Add(value);
        }

        return true;
    }

    private bool IsColumnValid(char[][] board, int columnId)
    {
        for (int i = 0; i < board[columnId].Length; i++)
        {
            var value = board[i][columnId];
            if (value == '.') continue;
            if (numbersSet.Contains(value)) return false;

            numbersSet.Add(value);
        }

        return true;
    }

    private bool IsBoxValid(char[][] board, int x, int y)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var value = board[i + x][j + y];
                if (value == '.') continue;
                if (numbersSet.Contains(value)) return false;

                numbersSet.Add(value);
            }
        }
        return true;
    }
}