namespace DomainDrivenDesign.DomainObjects
{
    public class Aggregate<T> : Entity<T> where T : Entity<T>
    {
        protected Aggregate(Id<T> id) : base(id)
        {
        }
    }
}
