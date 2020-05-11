using System;
using System.Collections.Generic;

namespace DomainDrivenDesign.DomainObjects
{
    public class Entity<T, TKey> : IEntity<T>
        where T : Entity<T, TKey>
        where TKey : Id
    {
        public TKey Id { get; }

        protected Entity(TKey id)
        {
            Id = id;
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
            return 2108858624 + Id.GetHashCode();
        }

#endregion
    }

    public class Entity<T> where T : Entity<T>
    {
        public Id<T> Id { get; }

        protected Entity(Id<T> id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Entity must have an id.");
        }

#region Equality

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            return left?.Id == right?.Id;
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }

        public bool Equals(Entity<T> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return this == obj as Entity<T>;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

#endregion
    }
}
