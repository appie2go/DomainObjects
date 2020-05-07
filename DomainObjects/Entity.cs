using System;

namespace DomainDrivenDesign.DomainObjects
{
    public class Entity<T, TKey> where T : Entity<T>
    {
        public Id<T, TKey> Id { get; }

        protected Entity(Id<T, TKey> id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Entity must have an id.");
        }

#region Equality

        public static bool operator ==(Entity<T, TKey> left, Entity<T, TKey> right)
        {
            return left?.Id == right?.Id;
        }

        public static bool operator !=(Entity<T, TKey> left, Entity<T, TKey> right)
        {
            return !(left == right);
        }

        public bool Equals(Entity<T, TKey> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return this == obj as Entity<T, TKey>;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 371;
        }
        #endregion
    }

    public class Entity<T> : Entity<T, Guid> where T : Entity<T>
    {
        protected Entity(Id<T> id) : base(id)
        {
        }
    }
}
