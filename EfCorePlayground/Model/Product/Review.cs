namespace EfCorePlayground.Model.Product
{
    using Framework;

    public class Review: Entity<int>
    {
        public string Content { get; set; }
    }
}