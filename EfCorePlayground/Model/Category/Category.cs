namespace EfCorePlayground.Model.Category
{
    using Framework;

    public class Category : Entity<CategoryId>
    {
        private Category() { }

        public static Category Create()
        {
            return new Category();
        }
    }
}