namespace Sandbox.Solutions.Medium;

public class SurroundedRegions
{
    public void Solve(char[][] board)
    {
        var visitedCoordinates = new HashSet<(int, int)>();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                visitedCoordinates.Clear();
                if (board[i][j] == 'O' && !HasBorder(j, i))
                    ColorBoard(j, i);
            }
        }

        return;

        void ColorBoard(int x, int y)
        {
            board[y][x] = 'X';

            if (x > 0 && board[y][x - 1] == 'O')
                ColorBoard(x - 1, y);

            if (x < board[y].Length - 1 && board[y][x + 1] == 'O')
                ColorBoard(x + 1, y);

            if (y > 0 && board[y - 1][x] == 'O')
                ColorBoard(x, y - 1);

            if (y < board.Length - 1 && board[y + 1][x] == 'O')
                ColorBoard(x, y + 1);
        }

        bool HasBorder(int x, int y)
        {
            if (x == 0 || y == 0 || x == board[y].Length - 1 || y == board.Length - 1)
                return true;

            visitedCoordinates.Add((y, x));
            var hasBorder = false;

            if (x > 0 && board[y][x - 1] == 'O' && !visitedCoordinates.Contains((y, x - 1)))
                hasBorder = hasBorder || HasBorder(x - 1, y);

            if (x < board[y].Length - 1 && board[y][x + 1] == 'O' && !visitedCoordinates.Contains((y, x + 1)))
                hasBorder = hasBorder || HasBorder(x + 1, y);

            if (y > 0 && board[y - 1][x] == 'O' && !visitedCoordinates.Contains((y - 1, x)))
                hasBorder = hasBorder || HasBorder(x, y - 1);

            if (y < board.Length - 1 && board[y + 1][x] == 'O' && !visitedCoordinates.Contains((y + 1, x)))
                hasBorder = hasBorder || HasBorder(x, y + 1);

            return hasBorder;
        }
    }
}