using Microsoft.EntityFrameworkCore;
using Tables.Models;

namespace Context
{
    public class ExamDbContext : DbContext
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS; Database=ElectricVehicle;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<ElectricVehicle> ElectricVehicle { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

