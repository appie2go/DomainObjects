using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.DomainObjects
{
    public sealed class Id<T> where T : Entity<T>
    {
        private readonly Guid _id;

        public Id(Guid id)
        {
            _id = id;

            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id), $"{id} is not a valid identifier.");
            }
        }

        public static Id<T> CreateNew()
        {
            return new Id<T>(Guid.NewGuid());
        }

        public override string ToString()
        {
            return _id.ToString();
        }

        public Guid ToGuid()
        {
            return _id;
        }


#region Equality

        public static bool operator ==(Id<T> left, Id<T> right)
        {
            return left?._id == right?._id;
        }

        public static bool operator !=(Id<T> left, Id<T> right)
        {
            return !(left == right);
        }

        public bool Equals(Id<T> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return this == obj as Id<T>;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

#endregion
    }
}
