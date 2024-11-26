using System;

class Program
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        string side = Console.ReadLine().ToLower();

        if (side == "right")
        {
            
            for (int i = 1; i <= height; i++)
            {
                Console.Write(new string(' ', height - i));
                Console.Write("*");

                if (i > 1)
                {
                    Console.Write(new string(' ', i - 2));
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
        else if (side == "left")
        {

            for (int i = 1; i <= height; i++)
            {
                Console.Write("*");


                if (i > 1)
                {
                    Console.Write(new string(' ', i - 2));
                    Console.Write("*");
                }


                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid orientation. Please enter 'left' or 'right'.");
        }
    }
}

