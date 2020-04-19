﻿using EfCorePlayground.Model.Brand;

namespace EfCorePlayground.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Product;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(e => e.Id).HasConversion(id => (int)id, id => new ProductId(id));

            builder.Property<BrandId>("_brandId").HasColumnName(nameof(BrandId));

            builder.HasOne<Brand>().WithMany().HasForeignKey("_brandId").IsRequired();

            builder.HasOne<Review>("_review").WithOne().IsRequired().HasForeignKey<Review>(nameof(ProductId));
            
            builder.HasMany<Comment>("_comments").WithOne().IsRequired().HasForeignKey(nameof(ProductId));

            builder.OwnsOne<ProductDetails>("_details", details =>
            {
                details.OwnsOne<Name>("_name", name => name
                    .Property<string>("_value")
                    .IsRequired()
                    .HasColumnName(nameof(Name)));

                details.OwnsOne<Description>("_description", description => description
                    .Property<string>("_value")
                    .IsRequired(false)
                    .HasColumnName(nameof(Description)));
            });

            builder.OwnsOne<Rating>("_rating", rating => rating
                .Property<int?>("_value")
                .IsRequired(false)
                .HasColumnName(nameof(Rating)));

            builder.OwnsMany<Image>("_images", images => images.ToTable("ProductImages")
                .Property<string>("_value")
                .IsRequired()
                .HasColumnName(nameof(Image)));

            builder.OwnsMany<Tag>("_tags", tags => tags.ToTable("ProductTags")
                .Property<string>("_value")
                .IsRequired()
                .HasColumnName(nameof(Tag)));
        }
    }
}