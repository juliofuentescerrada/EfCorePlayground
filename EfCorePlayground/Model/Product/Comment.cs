namespace EfCorePlayground.Model.Product
{
    using Framework;

    public class Comment : Entity<int>
    {
        public string Content { get; set; }
    }
}