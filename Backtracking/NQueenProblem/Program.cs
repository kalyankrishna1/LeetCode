using CommonLib;

namespace NQueenProblem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int [, ] inputBoard = ArrayHelper.GenerateMatrix(4,4, 0, 0);

            SolveNQueenProblem(4, inputBoard);

            Console.ReadKey();
        }

        private static void SolveNQueenProblem(int queens, int[,] inputBoard)
        {
            ArrayHelper.DisplayElementsWithPosition(inputBoard, "Input matrix follows...", true);

            int rows = inputBoard.GetLength(0);     // Rows
            int columns = inputBoard.GetLength(1);  //columns

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (IsSafeCell(inputBoard, i, j))
                    {
                        inputBoard[i, j] = 1;
                        //ArrayHelper.DisplayElementsWithPosition(inputBoard, "output matrix after assignment ...");
                    }
                }
            }

            ArrayHelper.DisplayElementsWithPosition(inputBoard, "Final output matrix ...", false);
        }

        /// <summary>
        /// A safe cell is a cell in the board where a queen can be placed on board[row,col] safely.
        /// </summary>
        private static bool IsSafeCell(int[,] inputBoard, int proposedRow, int proposedColumn)
        {
            int rows = inputBoard.GetLength(0);
            int columns = inputBoard.GetLength(1);

            // Can a queen attack from the left
            if (proposedColumn > 0)
            {
                for (int i = proposedColumn - 1; i >= 0; i--)
                {
                    if (inputBoard[proposedRow, i] == 1)
                    {
                        return false;
                    }
                }
            }

            // Can a queen attack from the top
            if (proposedRow > 0)
            {
                for (int i = proposedRow - 1; i >= 0; i--)
                {
                    if (inputBoard[i, proposedColumn] == 1)
                    {
                        return false;
                    }
                }
            }

            // Can a queen attack diagonally from top + left
            if (proposedRow > 0 && proposedColumn > 0)
            {
                for (int i = proposedRow - 1, j = proposedColumn - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (inputBoard[i, j] == 1)
                    {
                        return false;
                    }
                }
            }

            // Can a queen attack diagonally from bottom right
            if (proposedRow < rows && proposedColumn < columns)
            {
                for (int i = proposedRow + 1, j = proposedColumn + 1; i < rows && j < columns; i++, j++)
                {
                    if (inputBoard[i, j] == 1)
                    {
                        return false;
                    }
                }
            }

            // Can a queen attack from the right
            if (proposedColumn < columns)
            {
                for (int i = proposedColumn + 1; i < columns; i++)
                {
                    if (inputBoard[proposedRow, i] == 1)
                    {
                        return false;
                    }
                }
            }

            // Can a queen attack from the bottom
            if (proposedRow < rows)
            {
                for (int i = proposedRow + 1; i < rows; i++)
                {
                    if (inputBoard[i, proposedColumn] == 1)
                    {
                        return false;
                    }
                }
            }

            // Can a queen attack diagonally from top + right
            if (proposedRow < rows && proposedColumn > 0)
            {
                for (int i = proposedRow - 1, j = proposedColumn + 1; i >= 0 && j < columns; i--, j++)
                {
                    if (inputBoard[i, j] == 1)
                    {
                        return false;
                    }
                }
            }

            // Can a queen attack diagonally from bottom - left
            if (proposedRow > 0 && proposedColumn < columns)
            {
                for (int i = proposedRow - 1, j = proposedColumn + 1; i >= 0 && j < columns; i--, j++)
                {
                    if (inputBoard[i, j] == 1)
                    {
                        return false;
                    }
                }
            }

            Console.WriteLine($"[{proposedRow},{proposedColumn}]-{true}");

            return true;
        }
    }
}