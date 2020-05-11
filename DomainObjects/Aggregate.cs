using System;

namespace DomainDrivenDesign.DomainObjects
{
    public class Aggregate<T, TKey> : Entity<T, TKey>, IEntity<T>
        where T : Entity<T, TKey>
        where TKey : Id, IId<T>
    {
        protected Aggregate(TKey id) : base(id)
        {
        }
    }

    public class Aggregate<T> : Entity<T> where T : Aggregate<T>
    {
        protected Aggregate(Id<T> id) : base(id)
        {
        }
    }
}
