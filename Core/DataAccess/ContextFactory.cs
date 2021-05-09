using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class ContextFactory
    {
        public RecordStoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordStoreContext>();
            optionsBuilder.UseSqlServer(@"Data Source =@localhost;Initial Catalog = record_store_db; Integrated Security = True;");
            return new RecordStoreContext(optionsBuilder.Options);
        } 
    }
}