using EfCorePlayground.Model.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCorePlayground.EntitiesConfiguration
{
    public class CategoryEntityConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).HasConversion(id => (int)id, i => new CategoryId(i));
        }
    }
}