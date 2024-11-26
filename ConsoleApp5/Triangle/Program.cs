using System;

class Triangle
{
    static void Main(string[] args)
    {
      
        double sideA = double.Parse(Console.ReadLine());

        double sideB = double.Parse(Console.ReadLine());

        double sideC = double.Parse(Console.ReadLine());

        string result = DetermineTriangleType(sideA, sideB, sideC);
        Console.WriteLine($"The triangle is: {result}");
    }

    static string DetermineTriangleType(double sideA, double sideB, double sideC)
    {
        string result = "";

        if (!IsValidTriangle(sideA, sideB, sideC))
        {
            result = "Invalid triangle";
        }
        else if (sideA == sideB && sideB == sideC)
        {
            result = "Equilateral";
        }
        else if (sideA == sideB || sideB == sideC || sideA == sideC)
        {
            result = "Isosceles";
        }
        else
        {
            result = "Scalene";
        }

        return result;
    }

    static bool IsValidTriangle(double sideA, double sideB, double sideC)
    {
        bool isValid = true;

        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            isValid = false;
        }
        else if ((sideA + sideB < sideC) ||
                 (sideA + sideC < sideB) ||
                 (sideB + sideC < sideA))
        {
            isValid = false;
        }

        return isValid;
    }
}



