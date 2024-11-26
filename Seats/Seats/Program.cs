using System;

class Program
{
    static void Main(string[] args)
    {
        
        int nCols = int.Parse(Console.ReadLine());  
        int nRows = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());
        int row = int.Parse(Console.ReadLine());


        int rowsBehind = nRows - row; 
        int colsToLeft = col;         

        int disturbedPeople = rowsBehind * colsToLeft;

       
        Console.WriteLine(disturbedPeople);
    }
}
