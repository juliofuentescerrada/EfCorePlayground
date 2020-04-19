namespace EfCorePlayground.Model.Product
{
    using Framework;
    using System.Collections.Generic;

    public class Rating : ValueObject<Rating>
    {
        private readonly int? _value;

        public Rating(int? value) => _value = value;

        public override string ToString()
        {
            return _value.HasValue ? _value.ToString() : "pending";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}