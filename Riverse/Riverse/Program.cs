using System;

class Program
{
    static void Main(string[] args)
    {
       
        string input = Console.ReadLine();

        string reversed = ReverseString(input);
        Console.WriteLine($"Reversed string: {reversed}");
    }

    static string ReverseString(string str)
    {

        char[] charArray = str.ToCharArray();

        Array.Reverse(charArray);

        return new string(charArray);
    }
}

