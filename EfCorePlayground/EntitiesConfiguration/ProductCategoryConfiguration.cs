using EfCorePlayground.Model.Category;
using EfCorePlayground.Model.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCorePlayground.EntitiesConfiguration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey("_productId", "_categoryId");

            builder.HasOne<Product>("_product").WithMany();
            
            builder.HasOne<Category>("_category").WithMany();

            builder.ToTable("ProductCategories");
        }
    }
}