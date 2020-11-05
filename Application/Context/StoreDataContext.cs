using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Context.Maps;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Application.Context
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=prodcat;User ID=SA;Password=sql123sql");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { // aplica configs do productMap e CategoryMap
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}
// dotnet ef migrations add <migration-name>
// dotnet ef database update