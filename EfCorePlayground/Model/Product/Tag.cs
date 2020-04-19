namespace EfCorePlayground.Model.Product
{
    using Framework;
    using System.Collections.Generic;

    public class Tag : ValueObject<Name>
    {
        public static readonly Tag Refurbished = new Tag("Refurbished");
        public static readonly Tag New = new Tag("New");
        public static readonly Tag Used = new Tag("Used");

        private readonly string _value;

        public Tag(string value)
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