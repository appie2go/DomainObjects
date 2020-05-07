using System;

namespace DomainDrivenDesign.DomainObjects
{
    public abstract class Id<T, TKey> : Value<TKey> where T : Entity<T, TKey>
    {
        private readonly TKey _id;

        protected Id(TKey id) : base(id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return _id.ToString();
        }
    }

    public class Id<T> : Id<T, Guid> where T : Entity<T, Guid>
    {
        private readonly Guid _id;

        public static Id<T> New()
        {
            return new Id<T>(Guid.NewGuid());
        }

        public static Id<T> Create(Guid id)
        {
            return new Id<T>(id);
        }

        private Id(Guid id) : base(id)
        {
            _id = id;

            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id), $"{id} is not a valid identifier.");
            }
        }

        public Guid ToGuid()
        {
            return _id;
        }
    }
}
