namespace EfCorePlayground.Model.Product
{
    using Framework;
    using System.Collections.Generic;

    public class Image : ValueObject<Description>
    {
        private readonly string _value;

        public Image(string value)
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