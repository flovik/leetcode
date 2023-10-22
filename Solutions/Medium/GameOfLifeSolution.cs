namespace Sandbox.Solutions.Medium;

public class GameOfLifeSolution
{
    // down-left, down, down right, left, right, up-left, up, up-right
    private HashSet<(int, int)> directions = new()
        { (1, -1), (1, 0), (1, 1), (0, -1), (0, 1), (-1, -1), (-1, 0), (-1, 1) };

    public void GameOfLife(int[][] board)
    {
        // 0 - dead, 1 - live, 2 - gonna die, 3 - will live

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                int alive = 0;
                foreach (var (x, y) in directions)
                {
                    if (x + i < 0 || x + i >= board.Length || y + j < 0 || y + j >= board[i].Length) continue;
                    if (board[x + i][y + j] == 1 || board[x + i][y + j] == 2) alive++;
                    // calculate the alive ones (that are gonna die are also alive at the current state
                }

                if (board[i][j] == 0 && alive == 3) board[i][j] = 3; //rule that transforms a 0 into 1 (will be 3)
                if (board[i][j] == 1 && (alive < 2 || alive > 3)) board[i][j] = 2; //under-population over-population rules
            }
        }

        foreach (var line in board)
        {
            for (int j = 0; j < line.Length; j++)
            {
                line[j] %= 2;
            }
        }
    }
}