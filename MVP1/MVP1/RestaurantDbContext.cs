
using MVP1.Model;
using System.Data.Entity;

namespace MVP1
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }

        public RestaurantDbContext() : base("RestaurantDbContext")
        {
        }

    }
}
