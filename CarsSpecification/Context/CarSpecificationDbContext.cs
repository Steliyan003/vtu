using Microsoft.EntityFrameworkCore;
using Tables.Models;

namespace Context
{
    public class CarSpecificationDbContext:DbContext
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS; Database=cars;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<Car> Cars { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
