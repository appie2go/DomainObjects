using System;

namespace DomainDrivenDesign.DomainObjects
{
    public class Aggregate<T, TKey> : Entity<T, TKey> where T : Aggregate<T, TKey>
    {
        protected Aggregate(Id<T, TKey> id) : base(id)
        {
        }
    }

    public class Aggregate<T> : Aggregate<T, Guid> where T : Aggregate<T, Guid>
    {
        protected Aggregate(Id<T> id) : base(id)
        {
        }
    }
}
