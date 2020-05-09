using System;

namespace DomainDrivenDesign.DomainObjects
{
    public class PrimaryKey<T> where T : Entity<T>
    {
        private object _id;

        internal protected PrimaryKey(object id)
        {
            _id = id;

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        internal PrimaryKey(Guid id)
        {
            _id = id;

            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id), $"{id} is not a valid identifier.");
            }
        }

#region Equality
        public static bool operator ==(PrimaryKey<T> left, PrimaryKey<T> right)
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

        public static bool operator !=(PrimaryKey<T> left, PrimaryKey<T> right) =>  !(left == right);
        
        public bool Equals(Value<T> other) =>  Equals((object)other);
        
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

            if (!(obj is PrimaryKey<T>))
            {
                return false;
            }

            var other = (PrimaryKey<T>)obj;
            return object.Equals(_id, other._id);
        }

        public override int GetHashCode() =>  _id.GetHashCode();
#endregion


        public override string ToString() => _id.ToString();
    }
}
