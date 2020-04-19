namespace EfCorePlayground.Model.Product
{
    using Category;
    using Framework;
    using System;
    using System.Collections.Generic;

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