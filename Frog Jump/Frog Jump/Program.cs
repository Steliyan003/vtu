using System;

class Program
{
    static void Main(string[] args)
    {
        
        int X = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());

        
        int distance = Y - X; 
        int jumps = (distance + D - 1) / D; 


        Console.WriteLine($"Minimal number of jumps: {jumps}");
    }
}
