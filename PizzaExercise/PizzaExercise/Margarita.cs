using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaExercise
{
    public class Margarita:IPizza
    {
        private string name;
        private string size;
        private int quantity;
        private string date;
       

        public Margarita(string name, int quantity, string size,string date)
        {
            this.Name= name;
            this.Size = size;
            this.Quantity = quantity;
            this.Date = date;
            
        }

        public string Name
        {
            get { return name; }
            private set 
            { 
                if(string.IsNullOrWhiteSpace(value))
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

        public void GetTomato()
        {
            Console.WriteLine($"Tomato: {CalculateTomato(quantity)}");
        }

        private int Price(string size,int quantity)
        {
            int price = 0;
            if (size == "small")
            {
                price = 5 * quantity;
                
            }
            else if (size == "medium")
            {
                price = 10 * quantity;
            }
            else if(size=="large")
            {
                price = 15 * quantity;  
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
                dought= 500 * quantity;
            }
            else if(size== "large")
            {
                dought = 800 * quantity;
            }

            return $"Dough: {dought} grams";
        }

        private int CalculateTomato(int quantity)
        {
            int tomato = quantity * 1;
            return tomato;
        }


    }
}
