namespace EfCorePlayground.Model.Category
{
    using Framework;

    public class Category : Entity<CategoryId>
    {
        public string Name { get; private set; }

        private Category() { }

        public static Category Create(CategoryId id, string name)
        {
            return new Category
            {
                Id = id,
                Name = name
            };
        }
    }
}