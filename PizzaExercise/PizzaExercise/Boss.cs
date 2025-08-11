using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PizzaExercise
{
    public class Boss:IPizza
    {
        private string name;
        private string size;
        private int quantity;
        private string date;


        public Boss(string name, int quantity, string size, string date)
        {
            this.Name = name;
            this.Size = size;
            this.Quantity = quantity;
            this.Date = date;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
            }
        }

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            private set { quantity = value; }
        }

        public string Date
        {
            get { return date; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Date cannot be null or empty.");
                }
                date = value;
            }
        }


        public void GetPrice()
        {
            Console.WriteLine($"Total: ${Price(size, quantity)}"); 
        }

        public void GetDought()
        {
            Console.WriteLine(CalculateDought(quantity, size)); 
        }
        private int Price(string size, int quantity)
        {
            int price = 0;
            if (size == "small")
            {
                price = 20 * quantity;
                return price;
            }
            else if (size == "medium")
            {
                price = 25 * quantity;
            }
            else if (size == "large")
            {
                price = 30 * quantity;
            }

            return price;
        }

        private string CalculateDought(int quantity, string size)
        {
            int dought = 0;
            if (size == "small")
            {
                dought = 300 * quantity;
            }
            else if (size == "medium")
            {
                dought = 500 * quantity;
            }
            else if (size == "large")
            {
                dought = 800 * quantity;
            }

            return $"Pizza dough: {dought} grams";
        }

        public string GetHam(int quantity)
        {
            int result = 0;
            result= quantity * 100;
            Console.WriteLine($"Ham: {result} grams");
            return $"Ham: {result} grams";
        }
    }
}
