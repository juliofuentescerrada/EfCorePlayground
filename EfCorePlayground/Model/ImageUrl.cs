﻿namespace EfCorePlayground.Model
{
    using Framework;
    using System.Collections.Generic;

    public class ImageUrl : ValueObject<Description>
    {
        private readonly string _value;

        public ImageUrl(string value)
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