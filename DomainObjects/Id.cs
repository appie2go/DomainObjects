using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.DomainObjects
{
    /// <summary>
    /// A unique value used to identify either an aggregate or an entity
    /// </summary>
    public abstract class Id
    {
        internal Id() { }

#region Equality
        /// <summary>
        /// Compares the two Ids by value and returns a boolean value indicating the two Id's are equal.
        /// </summary>
        public static bool operator ==(Id left, Id right)
        {
            if (object.Equals(left, null) && object.Equals(right, null))
            {
                return true;
            }

            if (object.Equals(left, null) || object.Equals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Compares the two Ids by value and returns a boolean value indicating the two Id's are not equal.
        /// </summary>
        public static bool operator !=(Id left, Id right) => !(left == right);

        /// <summary>
        /// Compares the two Ids by value and returns a boolean value indicating the two Id's are equal.
        /// </summary>
        public bool Equals(Id other) => Equals((object)other);

        /// <summary>
        /// Compares the two Ids by value and returns a boolean value indicating the two Id's are equal.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (object.Equals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!(obj is Id))
            {
                return false;
            }

            var other = (Id)obj;
            return object.Equals(Value, other.Value);
        }

        public override int GetHashCode() => Value.GetHashCode();
#endregion

        protected abstract Type EntityType { get; }

        protected abstract object Value { get; }

        public override string ToString() => Value.ToString();
    }

    /// <summary>
    /// A type used to identify an entity or an aggregate, uses a globally unique identifier (Guid) as a value.
    /// </summary>
    /// <typeparam name="T">Identifies the type of entity/aggregate this Id refers to.</typeparam>
    [Serializable]
    public sealed class Id<T> : Id, ISerializable where T : Entity<T>
    {
        private readonly Guid _id;

        /// <summary>
        /// Creates a new instance of the Id class.
        /// </summary>
        /// <param name="id">The value of the id.</param>
        /// <returns>A new instance of the Id class.</returns>
        public static Id<T> Create(Guid id) => new Id<T>(id);

        /// <summary>
        /// Creates a new, unique instance of the Id class.
        /// </summary>
        /// <returns>A new, unique instance of the Id class.</returns>
        public static Id<T> New() => new Id<T>(Guid.NewGuid());

        private Id(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"{id} is not a valid id.");
            }

            _id = id;
        }

        protected override Type EntityType => typeof(T);

        protected override object Value => _id;

        /// <summary>
        /// Converts the Id to a Guid.
        /// </summary>
        /// <returns>A guid.</returns>
        public Guid ToGuid() => _id;

#region Serialization        
        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Id(SerializationInfo info, StreamingContext context)
        {
            var value = info.GetValue("id", _id.GetType()) ?? Guid.Empty;
            _id = (Guid) value;
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", _id);
        }
#endregion
    }

    [Serializable]
    public class Id<T, TType> : Id, ISerializable, IId<T> where T : IEntity<T>
    {
        private readonly TType _id;

        /// <summary>
        /// Creates a new instance of the id class.
        /// </summary>
        /// <param name="id">The unique value that identifies the entity or aggregate</param>
        public Id(TType id)
        {
            _id = id;
        }

        protected override Type EntityType => typeof(T);

        protected override object Value => _id;
        
#region Serialization        
        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Id(SerializationInfo info, StreamingContext context)
        {
            var value = info.GetValue("id", _id.GetType());
            _id = value == null ? default : (TType) value;
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", _id);
        }
#endregion
    }
}
