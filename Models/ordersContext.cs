using System.Data.Entity;

namespace Storage5.Models
{
    public class OrdersContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<CustomerProductOrder> CustomerProductOrders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}