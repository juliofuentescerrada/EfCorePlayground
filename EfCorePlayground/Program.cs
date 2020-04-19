namespace EfCorePlayground
{
    using System;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Model.Product;
    using System.Data;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new CatalogDbContext();

            CatalogDbContextDbContextInitializer.Seed(context);

            var id = CreateProduct(context);

            ListProducts(context);

            UpdateProduct(id, context);

            ListProducts(context);

            Console.Read();
        }

        private static ProductId CreateProduct(CatalogDbContext context)
        {
            var brand = context.Brands.ToList().Last();

            var categories = context.Categories.ToList();

            var productId = GetNextProductId(context);

            var details = new ProductDetails(new Name("Name"), null);

            var product = Product.Create(productId, details, brand, categories.ToArray());

            product.Tag(Tag.New, Tag.Refurbished, Tag.Used, Tag.New, Tag.Refurbished);

            product.SetReview(new Review { Content = "Lorem ipsum" });

            product.AddComment(new Comment { Content = "Nice!" });

            product.AddImage(new Image("foo"));

            context.Products.Add(product);

            context.SaveChanges();

            return productId;
        }

        private static void UpdateProduct(ProductId id, CatalogDbContext context)
        {
            var product = context.Products.Single(e => e.Id == id);

            var details = new ProductDetails(new Name("Updated name"), new Description("Updated description"));

            product.UpdateDetails(details);

            product.Tag(Tag.New, Tag.New);

            product.AddComment(new Comment { Content = "Awesome!" });

            product.AddImage(new Image("bar"));

            product.Rate(new Rating(10));

            context.SaveChanges();
        }

        private static void ListProducts(CatalogDbContext context)
        {
            var products = context.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        private static ProductId GetNextProductId(DbContext context)
        {
            var result = new SqlParameter("@result", SqlDbType.Int) { Direction = ParameterDirection.Output };

            context.Database.ExecuteSqlRaw("SELECT @result = (NEXT VALUE FOR products_id_sequence)", result);

            var productId = new ProductId((int)result.Value);

            return productId;
        }
    }
}
