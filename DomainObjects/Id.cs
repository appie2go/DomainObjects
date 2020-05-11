using System;
using System.ComponentModel;

namespace DomainDrivenDesign.DomainObjects
{
    public abstract class Id
    {
        internal Id() { }

#region Equality
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

        public static bool operator !=(Id left, Id right) => !(left == right);

        public bool Equals(Id other) => Equals((object)other);

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

    public class Id<T> : Id where T : Entity<T>
    {
        private readonly Guid _id;

        public static Id<T> Create(Guid id) => new Id<T>(id);

        public static Id<T> New() => new Id<T>(Guid.NewGuid());

        public Id(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"{id} is not a valid id.");
            }

            _id = id;
        }

        protected override Type EntityType => typeof(T);

        protected override object Value => _id;

        public Guid ToGuid() => _id;
    }

    public class Id<T, TType> : Id, IId<T> where T : IEntity<T>
    {
        private readonly TType _id;

        public Id(TType id)
        {
            _id = id;
        }

        protected override Type EntityType => typeof(T);

        protected override object Value => _id;
    }
}
