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
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Review>().ToTable("Reviews");
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

            if (!dbContext.Brands.Any())
            {
                dbContext.Brands.Add(Brand.Create(new BrandId(1), "Razer"));
                dbContext.Brands.Add(Brand.Create(new BrandId(2), "Logitech"));
                dbContext.Brands.Add(Brand.Create(new BrandId(3), "Corsair"));
            }

            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.Add(Category.Create(new CategoryId(1), "Home"));
                dbContext.Categories.Add(Category.Create(new CategoryId(2), "Gaming"));
                dbContext.Categories.Add(Category.Create(new CategoryId(3), "Professional"));
            }

            dbContext.SaveChanges();
        }
    }
}