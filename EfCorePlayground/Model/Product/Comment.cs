using EfCorePlayground.Framework;

namespace EfCorePlayground.Model.Product
{
    public class Comment : Entity<int>
    {
        public string Content { get; set; }
    }
}