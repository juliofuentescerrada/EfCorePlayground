namespace EfCorePlayground.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Brand;

    public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).HasConversion(id => (int)id, i => new BrandId(i));
        }
    }
}