using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.DomainObjects
{

    public class Value<T>
    {
        private readonly T _value;

        protected Value(T value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }


#region Equality

        public static bool operator ==(Value<T> left, Value<T> right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            return object.Equals(left._value, right._value);
        }

        public static bool operator !=(Value<T> left, Value<T> right)
        {
            return !(left == right);
        }

        public bool Equals(Value<T> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return this == obj as Value<T>;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

#endregion
    }

    public class Value<T1, T2> : Value<Tuple<T1, T2>>
    {
        protected Value(T1 value1, T2 value2) : base(new Tuple<T1, T2>(value1, value2))
        {
        }

        public override string ToString()
        {
            return GetType().ToString();
        }
    }

    public class Value<T1, T2, T3> : Value<Tuple<T1, T2, T3>>
    {
        protected Value(T1 value1, T2 value2, T3 value3) : base(new Tuple<T1, T2, T3>(value1, value2, value3))
        {
        }

        public override string ToString()
        {
            return GetType().ToString();
        }
    }

    public class Value<T1, T2, T3, T4> : Value<Tuple<T1, T2, T3, T4>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4) : base(new Tuple<T1, T2, T3, T4>(value1, value2, value3, value4))
        {
        }

        public override string ToString()
        {
            return GetType().ToString();
        }
    }

    public class Value<T1, T2, T3, T4, T5> : Value<Tuple<T1, T2, T3, T4, T5>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5) : base(new Tuple<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5))
        {
        }

        public override string ToString()
        {
            return GetType().ToString();
        }
    }
}
