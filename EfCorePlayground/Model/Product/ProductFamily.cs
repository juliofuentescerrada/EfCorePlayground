namespace EfCorePlayground.Model.Product
{
    using Family;

    public class ProductFamily
    {
        public Product Product { get; }
        public Family Family { get; }

        public ProductFamily(Product product, Family family)
        {
            Product = product;
            Family = family;
        }
    }
}