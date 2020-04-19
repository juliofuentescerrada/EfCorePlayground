namespace EfCorePlayground.Model.Brand
{
    using Framework;

    public class Brand : Entity<BrandId>
    {
        public string Name { get; private set; }

        private Brand() { }

        public static Brand Create(BrandId id, string name)
        {
            return new Brand
            {
                Id = id,
                Name = name
            };
        }
    }
}