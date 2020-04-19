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
            builder.Property<ProductId>("_productId")
                .HasColumnName(nameof(ProductId))
                .HasConversion(id => (int)id, i => new ProductId(i));

            builder.Property<CategoryId>("_categoryId")
                .HasColumnName(nameof(CategoryId))
                .HasConversion(id => (int)id, i => new CategoryId(i));

            builder.HasKey("_productId", "_categoryId");

            builder.HasOne<Product>().WithMany("_categories").HasForeignKey("_productId");
            
            builder.HasOne<Category>().WithMany().HasForeignKey("_categoryId");

            builder.ToTable("ProductCategories");
        }
    }
}