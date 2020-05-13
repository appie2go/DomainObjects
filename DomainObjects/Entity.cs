using System;
using System.Collections.Generic;

namespace DomainDrivenDesign.DomainObjects
{
    /// <summary>
    /// A cluster of domain objects that are mutable. Uniquely identified by id.
    /// </summary>
    /// <typeparam name="T">The type of the entity/The type that implements this class.</typeparam>
    /// <typeparam name="TKey">The type that is used to identify this entity.</typeparam>
    public class Entity<T, TKey> : IEntity<T>
        where T : Entity<T, TKey>
        where TKey : Id
    {
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        public TKey Id { get; }

        /// <summary>
        /// Creates a new instance of the Entity<<typeparamref name="T"/>, <typeparamref name="TKey"/>> class.
        /// </summary>
        /// <param name="id">A unique value that identifies this object.</param>
        protected Entity(TKey id)
        {
            Id = id;
        }

#region Equality

        /// <summary>
        /// Returns a boolean value indicating the two objects have the same id. (true or false)
        /// </summary>
        public static bool operator ==(Entity<T, TKey> left, Entity<T, TKey> right)
        {
            return left?.Id == right?.Id;
        }

        /// <summary>
        /// Returns a boolean value indicating the two objects have a different id. (true or false)
        /// </summary>
        public static bool operator !=(Entity<T, TKey> left, Entity<T, TKey> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a boolean value indicating the two objects have the same id. (true or false)
        /// </summary>
        public bool Equals(Entity<T, TKey> other)
        {
            return this == other;
        }

        /// <summary>
        /// Returns a boolean value indicating the two objects have the same id. (true or false)
        /// </summary>
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

    /// <summary>
    /// A cluster of domain objects that are mutable. Uniquely identified by id.
    /// </summary>
    /// <typeparam name="T">The type of the entity/The type that implements this class.</typeparam>
    public class Entity<T> where T : Entity<T>
    {
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        public Id<T> Id { get; }

        /// <summary>
        /// Creates a new instance of the Entity<<typeparamref name="T"/>> class.
        /// </summary>
        /// <param name="id">A unique value that identifies this object.</param>
        protected Entity(Id<T> id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Entity must have an id.");
        }

#region Equality

        /// <summary>
        /// Returns a boolean value indicating the two objects have the same id. (true or false)
        /// </summary>
        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            return left?.Id == right?.Id;
        }

        /// <summary>
        /// Returns a boolean value indicating the two objects have a different id. (true or false)
        /// </summary>
        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a boolean value indicating the two objects have the same id. (true or false)
        /// </summary>
        public bool Equals(Entity<T> other)
        {
            return this == other;
        }

        /// <summary>
        /// Returns a boolean value indicating the two objects have the same id. (true or false)
        /// </summary>
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
