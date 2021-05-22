using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class RecordStoreContext : DbContext
    {
        public RecordStoreContext(DbContextOptions<RecordStoreContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}