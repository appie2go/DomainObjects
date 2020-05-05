using System;

namespace DomainDrivenDesign.DomainObjects
{

    public class Value<T> : IComparable, IEquatable<Value<T>>
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

            if (object.Equals(left, null) && object.Equals(right, null))
            {
                return true;
            }

            if (object.Equals(left, null) || object.Equals(right, null))
            {
                return false;
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

        public virtual int CompareTo(object obj)
        {
            var comparable = this._value as IComparable;
            if (comparable == null)
            {
                throw new NotSupportedException("Type _value must derive from IComparable to be able to compare it.");
            }

            var valueToCompare = obj as Value<T>;
            if (valueToCompare == null)
            {
                throw new NotSupportedException($"Can't compare {obj.GetType()} to {this.GetType()}");
            }

            return comparable.CompareTo(valueToCompare._value);
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

    public class Value<T1, T2, T3, T4, T5, T6> : Value<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6) : base(new Tuple<T1, T2, T3, T4, T5, T6>(value1, value2, value3, value4, value5, value6))
        {
        }

        public override string ToString()
        {
            return GetType().ToString();
        }
    }


    public class Value<T1, T2, T3, T4, T5, T6, T7> : Value<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) : base(new Tuple<T1, T2, T3, T4, T5, T6, T7>(value1, value2, value3, value4, value5, value6, value7))
        {
        }

        public override string ToString()
        {
            return GetType().ToString();
        }
    }
}
