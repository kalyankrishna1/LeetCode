namespace CommonLib
{
    /// <summary>
    /// Some helper methods to deal with Arrays
    /// </summary>
    public static class ArrayHelper
    {
        /// <summary>
        /// Generates a neat two dimensional array. Optionally populates the array with randomly generated numbers 
        /// </summary>
        /// <param name="rows">The #rows in the two dimensional array</param>
        /// <param name="columns">The #columns in the two dimensional array</param>
        /// <param name="min">The min boundary of the random generator</param>
        /// <param name="max">The max boundary of the random number generator</param>
        /// <returns></returns>
        public static int[,] GenerateMatrix(int rows, int columns, int min = 1, int max = 99)
        {
            int[,] returnedMatrix = new int[rows, columns];

            Random randomInteger = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    returnedMatrix[i, j] = randomInteger.Next(min, max);
                }
            }

            return returnedMatrix;
        }


        /// <summary>
        /// Displays the elements with position on console.
        /// </summary>
        public static void DisplayElementsWithPosition(int[,] inputArray, string prefix = "", bool displaySize = false)
        {
            Console.ResetColor();
            Console.WriteLine($"{prefix}");

            int rows= inputArray.GetLength(0);
            int columns = inputArray.GetLength(1);
            string pad = "-----------";

            if (displaySize)
            {
                Console.WriteLine($"Size - Columns(M)-{columns}, Rows(N) -> {rows}  ");
            }

            for (int j = 0; j < columns; j++)
            {
                Console.Write(pad);
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("");

                for (int j = 0; j < columns; j++)
                {
                    Console.Write($" [{i},{j}] ");
                    ColorConsole.Write(ConsoleColor.Green, $"{inputArray[i, j]}");
                    Console.Write($" |");
                }

                Console.WriteLine("");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(pad);
                }
            }

            Console.WriteLine("");
        }

    }
}
