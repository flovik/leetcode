namespace Sandbox.Solutions.Medium;

public class Minesweeper
{
    private HashSet<(int, int)> processedCells = new();
    private Queue<(int, int)> cellsQueue = new Queue<(int, int)>();
    private int Rows;
    private int Columns;

    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        //M - unrevealed mine
        //E - unrevealed empty,
        //B - revealed black square (no adjacent mines)
        //digit - [1,8] how many mines are adjacent to this revealed square
        //X is the mine itself

        Rows = board.Length;
        Columns = board[0].Length;

        int i = click[0], j = click[1];
        int howMany = 0;
        switch (board[i][j])
        {
            case 'M':
                //if pressed a mine, change it to X
                board[i][j] = 'X';
                return board;
            case 'E':
                //first case when pressed cell is a digit
                if (IsInsideMatrix(i - 1, j)) //up
                {
                    if (IsMine(board, i - 1, j)) howMany++;
                    processedCells.Add((i - 1, j));
                    cellsQueue.Enqueue((i - 1, j));
                }
                if (IsInsideMatrix(i, j - 1)) //left
                {
                    if (IsMine(board, i, j - 1)) howMany++;
                    processedCells.Add((i, j - 1));
                    cellsQueue.Enqueue((i, j - 1));
                }
                if (IsInsideMatrix(i + 1, j)) //down
                {
                    if (IsMine(board, i + 1, j)) howMany++;
                    processedCells.Add((i + 1, j));
                    cellsQueue.Enqueue((i + 1, j));
                }

                if (IsInsideMatrix(i, j + 1)) //right
                {
                    if (IsMine(board, i, j + 1)) howMany++;
                    processedCells.Add((i, j + 1));
                    cellsQueue.Enqueue((i, j + 1));
                }

                if (IsInsideMatrix(i - 1, j - 1)) //up-left
                {
                    if (IsMine(board, i - 1, j - 1)) howMany++;
                    processedCells.Add((i - 1, j - 1));
                    cellsQueue.Enqueue((i - 1, j - 1));
                }
                if (IsInsideMatrix(i - 1, j + 1)) //up-right
                {
                    if (IsMine(board, i - 1, j + 1)) howMany++;
                    processedCells.Add((i - 1, j + 1));
                    cellsQueue.Enqueue((i - 1, j + 1));
                }
                if (IsInsideMatrix(i + 1, j - 1)) //down-left
                {
                    if (IsMine(board, i + 1, j - 1)) howMany++;
                    processedCells.Add((i + 1, j - 1));
                    cellsQueue.Enqueue((i + 1, j - 1));
                }
                if (IsInsideMatrix(i + 1, j + 1)) //down-right
                {
                    if (IsMine(board, i + 1, j + 1)) howMany++;
                    processedCells.Add((i + 1, j + 1));
                    cellsQueue.Enqueue((i + 1, j + 1));
                }

                processedCells.Add((i, j));
                board[i][j] = 'B';

                break;
        }

        //the cell that was pressed was adjacent to a mine, so only it wll be changed
        if (howMany != 0)
        {
            board[i][j] = howMany.ToString()[0];
        }
        else
        {
            //if it is an empty cell, we go recursively to reveal other cells
            while (cellsQueue.Count > 0)
            {
                for (int k = 0; k < board.Length; k++)
                {
                    for (int l = 0; l < board[k].Length; l++)
                    {
                        Console.Write(board[k][l] + ' '.ToString());
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                (i, j) = cellsQueue.Dequeue();
                howMany = 0;
                if (IsInsideMatrix(i - 1, j) && IsMine(board, i - 1, j)) howMany++;
                if (IsInsideMatrix(i, j - 1) && IsMine(board, i, j - 1)) howMany++;
                if (IsInsideMatrix(i + 1, j) && IsMine(board, i + 1, j)) howMany++;
                if (IsInsideMatrix(i, j + 1) && IsMine(board, i, j + 1)) howMany++;
                if (IsInsideMatrix(i - 1, j - 1) && IsMine(board, i - 1, j - 1)) howMany++;
                if (IsInsideMatrix(i - 1, j + 1) && IsMine(board, i - 1, j + 1)) howMany++;
                if (IsInsideMatrix(i + 1, j - 1) && IsMine(board, i + 1, j - 1)) howMany++;
                if (IsInsideMatrix(i + 1, j + 1) && IsMine(board, i + 1, j + 1)) howMany++;
                
                //case when current stack cell is a digit
                if (howMany > 0)
                {
                    board[i][j] = howMany.ToString()[0];
                    continue;
                }

                //case when a simple blank cell
                if (IsInsideMatrix(i - 1, j) && !IsDigit(board, i - 1, j) && !processedCells.Contains((i - 1, j)))
                {
                    cellsQueue.Enqueue((i - 1, j));
                    processedCells.Add((i - 1, j));
                }

                if (IsInsideMatrix(i, j - 1) && !IsDigit(board, i, j - 1) && !processedCells.Contains((i, j - 1)))
                {
                    cellsQueue.Enqueue((i, j - 1));
                    processedCells.Add((i, j - 1));
                }

                if (IsInsideMatrix(i + 1, j) && !IsDigit(board, i + 1, j) && !processedCells.Contains((i + 1, j)))
                {
                    cellsQueue.Enqueue((i + 1, j));
                    processedCells.Add((i + 1, j));
                }

                if (IsInsideMatrix(i, j + 1) && !IsDigit(board, i, j + 1) && !processedCells.Contains((i, j + 1)))
                {
                    cellsQueue.Enqueue((i, j + 1));
                    processedCells.Add((i, j + 1));
                }

                if (IsInsideMatrix(i - 1, j - 1) && !IsDigit(board, i - 1, j - 1) && !processedCells.Contains((i - 1, j - 1)))
                {
                    cellsQueue.Enqueue((i - 1, j - 1));
                    processedCells.Add((i - 1, j - 1));
                }

                if (IsInsideMatrix(i - 1, j + 1) && !IsDigit(board, i - 1, j + 1) && !processedCells.Contains((i - 1, j + 1)))
                {
                    cellsQueue.Enqueue((i - 1, j + 1));
                    processedCells.Add((i - 1, j + 1));
                }

                if (IsInsideMatrix(i + 1, j - 1) && !IsDigit(board, i + 1, j - 1) && !processedCells.Contains((i + 1, j - 1)))
                {
                    cellsQueue.Enqueue((i + 1, j - 1));
                    processedCells.Add((i + 1, j - 1));
                }

                if (IsInsideMatrix(i + 1, j + 1) && !IsDigit(board, i + 1, j + 1) && !processedCells.Contains((i + 1, j + 1)))
                {
                    cellsQueue.Enqueue((i + 1, j + 1));
                    processedCells.Add((i + 1, j + 1));
                }

                board[i][j] = 'B';
            }
        }

        for (int k = 0; k < board.Length; k++)
        {
            for (int l = 0; l < board[k].Length; l++)
            {
                Console.Write(board[k][l] + ' '.ToString());
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        return board;
    }

    private bool IsInsideMatrix(int i, int j) => i >= 0 && j >= 0 && i < Rows && j < Columns;
    private bool IsMine(char[][] board, int i, int j) => board[i][j] == 'M';
    private bool IsDigit(char[][] board, int i, int j) => board[i][j] >= '1' && board[i][j] <= '8';
}