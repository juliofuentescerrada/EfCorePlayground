namespace EfCorePlayground.Model.Product
{
    using Framework;
    using System.Collections.Generic;

    public class Description : ValueObject<Description>
    {
        private readonly string _value;

        public Description(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}