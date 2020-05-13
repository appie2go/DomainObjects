using System;

namespace DomainDrivenDesign.DomainObjects
{

    public class Value<T> : IEquatable<Value<T>>
    {
        private readonly T _value;

        protected Value(T value)
        {
            _value = value;
        }

        public override string ToString() => _value.ToString();

        #region Equality

        public static bool operator ==(Value<T> left, Value<T> right)
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

        public static bool operator !=(Value<T> left, Value<T> right) => !(left == right);

        public bool Equals(Value<T> other) => Equals((object)other);

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

            if (!(obj is Value<T>))
            {
                return false;
            }

            var other = (Value<T>)obj;
            return object.Equals(_value, other._value);
        }

        public override int GetHashCode() => _value.GetHashCode();
        #endregion
    }

    public class Value<T1, T2> : Value<Tuple<T1, T2>>
    {
        protected Value(T1 value1, T2 value2)
            : base(new Tuple<T1, T2>(value1, value2))
        {
        }

        public override string ToString() => GetType().ToString();
    }

    public class Value<T1, T2, T3> : Value<Tuple<T1, T2, T3>>
    {
        protected Value(T1 value1, T2 value2, T3 value3)
            : base(new Tuple<T1, T2, T3>(value1, value2, value3))
        {
        }

        public override string ToString() => GetType().ToString();
    }

    public class Value<T1, T2, T3, T4> : Value<Tuple<T1, T2, T3, T4>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4)
            : base(new Tuple<T1, T2, T3, T4>(value1, value2, value3, value4))
        {
        }

        public override string ToString() => GetType().ToString();
    }

    public class Value<T1, T2, T3, T4, T5> : Value<Tuple<T1, T2, T3, T4, T5>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            : base(new Tuple<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5))
        {
        }

        public override string ToString() => GetType().ToString();
    }

    public class Value<T1, T2, T3, T4, T5, T6> : Value<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            : base(new Tuple<T1, T2, T3, T4, T5, T6>(value1, value2, value3, value4, value5, value6))
        {
        }

        public override string ToString() => GetType().ToString();
    }

    public class Value<T1, T2, T3, T4, T5, T6, T7> : Value<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            : base(new Tuple<T1, T2, T3, T4, T5, T6, T7>(value1, value2, value3, value4, value5, value6, value7))
        {
        }

        public override string ToString() => GetType().ToString();
    }

    public class Value<T1, T2, T3, T4, T5, T6, T7, T8> : Value<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
            : base(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(value1, value2, value3, value4, value5, value6, value7, value8))
        {
        }

        public override string ToString() => GetType().ToString();
    }
}
