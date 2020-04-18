namespace EfCorePlayground.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    { public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).HasConversion(id => (int) id, i => new ProductId(i));

            builder.OwnsOne<ProductDetails>("_details", d =>
            {
                d.OwnsOne<Name>("_name", n => n
                    .Property<string>("_value")
                    .IsRequired()
                    .HasColumnName(nameof(Name)));

                d.OwnsOne<Description>("_description", d => d
                    .Property<string>("_value")
                    .IsRequired(false)
                    .HasColumnName(nameof(Description)));
            });

            builder.OwnsOne<Rating>("_rating", n => n
                .Property<int?>("_value")
                .IsRequired(false)
                .HasColumnName(nameof(Rating)));


            builder.OwnsMany<ImageUrl>("_images", i => i.ToTable("ProductImages")
                    .Property<string>("_value")
                    .IsRequired()
                    .HasColumnName(nameof(ImageUrl)));

            builder.OwnsMany<Tag>("_tags", t => t.ToTable("ProductTags")
                .Property<string>("_value")
                .IsRequired()
                .HasColumnName(nameof(Tag)));
        }
    }
}