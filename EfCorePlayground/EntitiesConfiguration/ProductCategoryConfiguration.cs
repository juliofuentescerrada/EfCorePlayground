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
            builder.Property<ProductId>(nameof(ProductId));

            builder.Property<CategoryId>("_categoryId")
                .HasColumnName(nameof(CategoryId))
                .HasConversion(id => (int)id, i => new CategoryId(i));

            builder.HasOne<Product>().WithMany("_categories").HasForeignKey(nameof(ProductId));
            
            builder.HasOne<Category>().WithMany().HasForeignKey("_categoryId");

            builder.HasKey(nameof(ProductId), "_categoryId");

            builder.ToTable("ProductCategories");
        }
    }
}