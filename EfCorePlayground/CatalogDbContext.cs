using EfCorePlayground.Model.Brand;
using EfCorePlayground.Model.Category;

namespace EfCorePlayground
{
    using Microsoft.EntityFrameworkCore;
    using Model;
    using Model.Product;
    using System.Linq;

    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Playground;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("products_id_sequence");
            modelBuilder.HasSequence("brands_id_sequence");
            modelBuilder.HasSequence("categories_id_sequence");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        }
    }

    public static class CatalogDbContextDbContextInitializer
    {
        public static void Seed(CatalogDbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}