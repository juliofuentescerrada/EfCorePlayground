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

            var productId = GetNextProductId(context);

            var details = new ProductDetails(new Name("Name"), null);

            var newProduct = Product.Create(productId, details, null);

            newProduct.AddImage(new ImageUrl("foo"));

            newProduct.SetTags(Tag.New, Tag.Refurbished, Tag.Used);

            context.Products.Add(newProduct);

            context.SaveChanges();

            ListProducts(context);
        }

        private static void ListProducts(CatalogDbContext context)
        {
            var products = context.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }

            Console.Read();
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
