using Microsoft.EntityFrameworkCore;
using RabbitMQWithNet.Models;

namespace RabbitMQWithNet.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product> Products { get; set; }
    }
}
