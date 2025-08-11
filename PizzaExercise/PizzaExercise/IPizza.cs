using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaExercise
{
    public interface IPizza
    {
        public string Name { get; }
        public string Size { get; }
        public int Quantity { get; }
        public string Date { get; }


        public void GetDought();
        public void GetPrice();
    }
}
