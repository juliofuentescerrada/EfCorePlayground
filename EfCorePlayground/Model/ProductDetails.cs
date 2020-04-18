namespace EfCorePlayground.Model
{
    using Framework;
    using System.Collections.Generic;

    public class ProductDetails : ValueObject<ProductDetails>
    {
        private Name _name;
        private Description _description;

        private ProductDetails() { }

        public ProductDetails(Name name, Description description)
        {
            _name = name;
            _description = description;
        }

        public override string ToString()
        {
            return $"{_name} - {_description}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _name;
            yield return _description;
        }
    }
}