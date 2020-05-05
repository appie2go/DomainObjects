using System;

namespace DomainDrivenDesign.DomainObjects
{
    public sealed class Id<T> : Value<Guid> where T : Entity<T>
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


        public override string ToString()
        {
            return _id.ToString();
        }

        public Guid ToGuid()
        {
            return _id;
        }
    }
}
