namespace EfCorePlayground.Model.Product
{
    using Category;
    public class ProductCategory
    {
        private ProductId _productId;
        private CategoryId _categoryId;

        private ProductCategory() { }

        public ProductCategory(Product product, Category category)
        {
            _productId = product.Id;
            _categoryId = category.Id;
        }
    }
}