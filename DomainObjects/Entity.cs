using System;
using System.Collections.Generic;

namespace DomainDrivenDesign.DomainObjects
{
    public class Entity<T, TKey> : Entity<T> 
        where T : Entity<T>
        where TKey : PrimaryKey<T>
    {
        public TKey Id { get; }

        protected Entity(TKey id) : base(id)
        {
            Id = id;
        }
    }

    public class Entity<T> where T : Entity<T>
    {
        public PrimaryKey<T> Id { get; }

        protected Entity(PrimaryKey<T> id)
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
