using System.Linq;

namespace EfCorePlayground.Model.Product
{
    using Brand;
    using Framework;
    using System.Collections.Generic;

    public class Product : Entity<ProductId>
    {
        private ProductDetails _details;
        private Rating _rating;
        private ICollection<Image> _images = new HashSet<Image>();
        private ICollection<Tag> _tags = new HashSet<Tag>();

        private BrandId _brandId;
        private Review _review;
        private ICollection<Comment> _comments = new List<Comment>();
        private ICollection<ProductCategory> _categories = new List<ProductCategory>();

        private Product() { }

        public static Product Create(ProductId productId, ProductDetails details, Brand brand, params Category.Category[] categories)
        {
            var product = new Product
            {
                Id = productId,
                _details = details,
                _brandId = brand.Id,
                _categories = categories?.Select(category => new ProductCategory(category.Id)).ToList()
            };

            return product;
        }

        public override string ToString()
        {
            return $"{Id} - {_details}: Rating {_rating}. Tags: {string.Join(",", _tags)}";
        }

        public void UpdateDetails(ProductDetails details)
        {
            _details = details;
        }

        public void AddImage(Image imageUrl)
        {
            _images.Add(imageUrl);
        }

        public void Tag(params Tag[] tags)
        {
            _tags = new HashSet<Tag>(tags);
        }

        public void Rate(Rating rating)
        {
            _rating = rating;
        }

        public void SetReview(Review review)
        {
            _review = review;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}