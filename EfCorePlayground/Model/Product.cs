namespace EfCorePlayground.Model
{
    using Framework;
    using System.Collections.Generic;

    public class Product : Entity<ProductId>
    {
        private ProductDetails _details;
        private ICollection<ImageUrl> _images = new List<ImageUrl>();
        private ICollection<Tag> _tags = new List<Tag>();

        private Product() { }

        public static Product Create(ProductId productId, ProductDetails details)
        {
            return new Product
            {
                Id = productId,
                _details = details
            };
        }

        public override string ToString()
        {
            return $"{Id} - {_details}";
        }

        public void AddImage(ImageUrl imageUrl)
        {
            _images.Add(imageUrl);
        }

        public void SetTags(params Tag[] tags)
        {
            _tags = new List<Tag>(tags);
        }
    }
}