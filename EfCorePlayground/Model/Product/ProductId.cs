namespace EfCorePlayground.Model.Product
{
    using Framework;
    using System.Collections.Generic;

    public class ProductId : ValueObject<ProductId>
    {
        private readonly int _value;

        public ProductId(int value) => _value = value;

        public static explicit operator int(ProductId id) => id._value;

        public override string ToString() => _value.ToString();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}