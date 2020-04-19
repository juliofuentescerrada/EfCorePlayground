namespace EfCorePlayground.Model.Category
{
    using Framework;
    using Product;
    using System.Collections.Generic;

    public class CategoryId : ValueObject<CategoryId>
    {
        private readonly int _value;

        public CategoryId(int value)
        {
            _value = value;
        }

        public static explicit operator int(CategoryId id) => id._value;

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