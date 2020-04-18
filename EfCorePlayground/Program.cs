namespace EfCorePlayground
{
    using System;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Model;
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
            var productId = GetNextProductId(context);

            var details = new ProductDetails(new Name("Name"), null);

            var product = Product.Create(productId, details, new Rating(null));

            product.AddImage(new ImageUrl("foo"));

            product.SetTags(Tag.New, Tag.Refurbished, Tag.Used);

            context.Products.Add(product);

            context.SaveChanges();

            return productId;
        }

        private static void UpdateProduct(ProductId id, CatalogDbContext context)
        {
            var product = context.Products.Find(id);

            product.UpdateDetails(new ProductDetails(new Name("Updated name"), new Description("Updated description")));

            product.AddImage(new ImageUrl("foo"));

            product.SetTags(Tag.New);

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
