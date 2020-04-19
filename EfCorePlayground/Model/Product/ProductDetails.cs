namespace EfCorePlayground.Model.Product
{
    using Framework;
    using System.Collections.Generic;

    public class ProductDetails : ValueObject<ProductDetails>
    {
        private readonly Name _name;
        private readonly Description _description;

        private ProductDetails() { }

        public ProductDetails(Name name, Description description)
        {
            _name = name;
            _description = description;
        }

        public override string ToString() => $"{_name} - {_description}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _name;
            yield return _description;
        }
    }
}