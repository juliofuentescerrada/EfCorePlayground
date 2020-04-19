namespace EfCorePlayground.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Category;

    public class CategoryEntityConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).HasConversion(id => (int)id, i => new CategoryId(i));
        }
    }
}