namespace Chess_board
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalSquares = 64;
            ulong totalGrains = 0;

            Console.WriteLine("Grains of wheat on each square of the chessboard:");

            // Преминете през всеки квадрат и изчислете броя на зърната
            for (int i = 1; i <= totalSquares; i++)
            {
                ulong grainsOnSquare = (ulong)Math.Pow(2, i - 1);
                totalGrains += grainsOnSquare;

                // Изведете броя на зърната в текущия квадрат
                Console.WriteLine($"Square {i}: {grainsOnSquare} grains");
            }

            // Изведете общия брой зърна на шахматната дъска
            Console.WriteLine($"\nTotal number of grains on the chessboard: {totalGrains}");
        }
    }
}
