namespace EfCorePlayground.Model.Category
{
    using Framework;

    public class Category : Entity<CategoryId>
    {
        public string Name { get; private set; }
        private Category() { }

        public static Category Create(string name)
        {
            return new Category
            {
                Name = name
            };
        }
    }
}