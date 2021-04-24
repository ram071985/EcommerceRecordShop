using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class ContextFactory
    {
        public OrderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseSqlServer(@"Data Source =.\SQLSERVER;Initial Catalog = YourDBName; Integrated Security = True;");
            return new OrderContext(optionsBuilder.Options);
        } 
    }
}