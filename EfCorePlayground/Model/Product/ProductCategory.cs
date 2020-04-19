using System;

namespace EfCorePlayground.Model.Product
{
    using Category;

    public class ProductCategory
    {
        private CategoryId _categoryId;

        public ProductCategory(CategoryId categoryId)
        {
            _categoryId = categoryId ?? throw new ArgumentNullException(nameof(categoryId));
        }
    }
}