namespace EfCorePlayground.Model.Family
{
    using Framework;

    public class Family : Entity<FamilyId>
    {
        private Family() { }

        public static Family Create()
        {
            return new Family();
        }
    }
}