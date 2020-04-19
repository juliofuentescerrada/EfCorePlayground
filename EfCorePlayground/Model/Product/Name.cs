namespace EfCorePlayground.Model.Product
{
    using Framework;
    using System.Collections.Generic;

    public class Name : ValueObject<Name>
    {
        private readonly string _value;

        public Name(string value)
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