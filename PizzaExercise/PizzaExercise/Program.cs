using System.Drawing;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write Pizza, name, quantity, size and data");
            string[] input = Console.ReadLine().Split(' ').ToArray();
            List<Boss> boss= new List<Boss>();
            List<Margarita> margarita = new List<Margarita>();

            while(!input.Contains("end"))
            {
                if(input.Length==5)
                {
                    
                    string name= input[1];
                    if(name=="Margarita")
                    {
                        int quantity = int.Parse(input[2]);
                        string size = input[3];
                        string date = input[4];
                        Margarita pizzaMargarita = new Margarita(name, quantity, size, date);
                        margarita.Add(pizzaMargarita);
                        Console.WriteLine("Margarita preparing… ");
                        pizzaMargarita.GetDought();
                        pizzaMargarita.GetTomato();
                        pizzaMargarita.GetPrice();
                    }
                    else if (name == "Boss")
                    {
                        int quantity = int.Parse(input[2]);
                        string size = input[3];
                        string date = input[4];
                        Boss pizzaBoss = new Boss(name, quantity, size, date);
                        boss.Add(pizzaBoss);
                        Console.WriteLine("Boss pizza preparing...");
                        pizzaBoss.GetDought();
                        pizzaBoss.GetHam(quantity);
                        pizzaBoss.GetPrice(); 
                    }
                }
                input = Console.ReadLine().Split(' ').ToArray();
            }

            foreach(var margarita1 in margarita)
            {
                Console.WriteLine("Cash register reset:");
                Console.WriteLine(margarita1.Date);
                Console.WriteLine($"Tottal pizzas {margarita1.Quantity}");
                Console.WriteLine($"Margarita pizzas {margarita1.Quantity}");
                margarita1.GetPrice();
            }

            foreach (var boss1 in boss)
            {
                Console.WriteLine("Cash register reset:");
                Console.WriteLine(boss1.Date);
                Console.WriteLine($"Tottal pizzas {boss1.Quantity}");
                Console.WriteLine($"Boss pizzas {boss1.Quantity}");
                boss1.GetPrice();
            }
        }
    }
}
