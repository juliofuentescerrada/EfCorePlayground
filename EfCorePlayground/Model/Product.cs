namespace EfCorePlayground.Model
{
    using Framework;
    using System.Collections.Generic;

    public class Product : Entity<ProductId>
    {
        private ProductDetails _details;
        private Rating _rating;
        private ICollection<ImageUrl> _images = new List<ImageUrl>();
        private Tags _tags;

        private Product() { }

        public static Product Create(ProductId productId, ProductDetails details, Rating rating)
        {
            return new Product
            {
                Id = productId,
                _details = details,
                _rating = rating
            };
        }

        public override string ToString()
        {
            return $"{Id} - {_details}: Rating {_rating}";
        }

        public void UpdateDetails(ProductDetails details)
        {
            _details = details;
        }

        public void AddImage(ImageUrl imageUrl)
        {
            _images.Add(imageUrl);
        }

        public void SetTags(params Tag[] tags)
        {
            _tags = new Tags(tags);
        }

        public void Rate(Rating rating)
        {
            _rating = rating;
        }
    }
}