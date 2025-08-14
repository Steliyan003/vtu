using Microsoft.EntityFrameworkCore;
using Tables.Models;

namespace Context
{
    public class MoviesDbContext:DbContext
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS; Database=movies;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<Movies> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Cast> Cast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
