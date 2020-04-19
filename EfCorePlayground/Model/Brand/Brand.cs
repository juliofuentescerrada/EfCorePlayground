namespace EfCorePlayground.Model.Brand
{
    using Framework;

    public class Brand : Entity<BrandId>
    {
        private Brand() { }

        public static Brand Create()
        {
            return new Brand();
        }
    }
}