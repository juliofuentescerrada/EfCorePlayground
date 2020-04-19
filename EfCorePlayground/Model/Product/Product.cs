﻿namespace EfCorePlayground.Model.Product
{
    using Brand;
    using Category;
    using Family;
    using Framework;
    using System.Collections.Generic;
    using System.Linq;

    public class Product : Entity<ProductId>
    {
        private ProductDetails _details;
        private Rating _rating;
        private ICollection<Image> _images = new HashSet<Image>();
        private ICollection<Tag> _tags = new HashSet<Tag>();

        private Brand _brand;

        private ICollection<Category> _categories = new List<Category>();
        public IEnumerable<Category> Categories => _categories.ToList();

        private ICollection<ProductFamily> _families = new List<ProductFamily>();
        public IEnumerable<Family> Families => _families.Select(e => e.Family).ToList();


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
            return $"{Id} - {_details}: Rating {_rating}. Tags: {_tags}";
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
    }
}