using System;

namespace DomainDrivenDesign.DomainObjects
{
    public class NumericValue<T> : Value<T>, IComparable<NumericValue<T>>, IComparable where T : IComparable<T>
    {
        private readonly T _value;

        protected NumericValue(T value) : base(value)
        {
            _value = value;
        }

        public static bool operator <(NumericValue<T> left, NumericValue<T> right)
        {
            return left._value.CompareTo(right._value) < 0;
        }

        public static bool operator >(NumericValue<T> left, NumericValue<T> right)
        {
            return !(left < right) && left != right;
        }

        public static bool operator <=(NumericValue<T> left, NumericValue<T> right)
        {
            return left < right || left == right;
        }

        public static bool operator >=(NumericValue<T> left, NumericValue<T> right)
        {
            return left > right || left == right;
        }

        public int CompareTo(NumericValue<T> other)
        {
            var comparable = this._value as IComparable;
            if (comparable == null)
            {
                throw new NotSupportedException("Type _value must derive from IComparable to be able to compare it.");
            }

            return comparable.CompareTo(other._value);
        }

        public int CompareTo(object obj)
        {
            var other = obj as NumericValue<T>;
            if (other == null)
            {
                throw new NotSupportedException($"Cannot compare {obj} to {this.GetType()}");
            }

            return CompareTo(other);
        }
    }
}
