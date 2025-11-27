using System.Collections.Generic;

namespace WebProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
