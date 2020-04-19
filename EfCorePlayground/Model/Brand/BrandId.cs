namespace EfCorePlayground.Model.Brand
{
    using Framework;
    using System.Collections.Generic;

    public class BrandId : ValueObject<BrandId>
    {
        private readonly int _value;

        public BrandId(int value) => _value = value;

        public static explicit operator int(BrandId id) => id._value;

        public override string ToString() => _value.ToString();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}