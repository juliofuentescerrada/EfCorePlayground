using System;
using System.Collections.Generic;
using EfCorePlayground.Framework;

namespace EfCorePlayground.Model.Product
{
    using Category;

    public class ProductCategory: ValueObject<ProductCategory>
    {
        private readonly CategoryId _categoryId;

        public ProductCategory(CategoryId categoryId)
        {
            _categoryId = categoryId ?? throw new ArgumentNullException(nameof(categoryId));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _categoryId;
        }
    }
}