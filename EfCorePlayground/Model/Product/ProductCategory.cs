namespace EfCorePlayground.Model.Product
{
    using Category;
    public class ProductCategory
    {
        private Product _product;
        private ProductId _productId;

        private Category _category;
        private CategoryId _categoryId;

        private ProductCategory() { }

        public ProductCategory(Product product, Category category)
        {
            _product = product;
            _productId = _product.Id;

            _category = category;
            _categoryId = _category.Id;
        }
    }
}