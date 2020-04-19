namespace EfCorePlayground.Model.Family
{
    using Framework;
    using Product;
    using System.Collections.Generic;

    public class FamilyId : ValueObject<FamilyId>
    {
        private readonly int _value;

        public FamilyId(int value)
        {
            _value = value;
        }

        public static explicit operator int(ProductId id) => id._value;

        public override string ToString()
        {
            return _value.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}