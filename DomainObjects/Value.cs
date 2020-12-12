using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.DomainObjects
{
    /// <summary>
    /// An immutable object. 
    /// </summary>
    [Serializable]
    public class Value<T> : IEquatable<Value<T>>, ISerializable
    {
        private readonly T _value;

        /// <summary>
        /// Creates a new instance of the Value class.
        /// </summary>
        /// <param name="value">The value.</param>
        protected Value(T value)
        {
            _value = value;
        }

        public override string ToString() => _value?.ToString();
        
#region Serialization
        
        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context)
        {
            var value = info.GetValue("values", typeof(T));
            _value = value == default ? default : (T)value;
        }
        
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("values", _value);
        }
        
#endregion

#region Equality

        /// <summary>
        /// Compares the two values and returns a boolean value indicating the two objects have are equal.
        /// </summary>
        public static bool operator ==(Value<T> left, Value<T> right)
        {
            if (Equals(left, null) && Equals(right, null))
            {
                return true;
            }

            if (Equals(left, null) || Equals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Compares the two values and returns a boolean value indicating the two objects have are unequal.
        /// </summary>
        public static bool operator !=(Value<T> left, Value<T> right) => !(left == right);

        /// <summary>
        /// Compares the two values and returns a boolean value indicating the two objects have are equal.
        /// </summary>
        public bool Equals(Value<T> other) => Equals((object)other);

        /// <summary>
        /// Compares the two values and returns a boolean value indicating the two objects have are equal.
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

            if (!(obj is Value<T>))
            {
                return false;
            }

            var other = (Value<T>)obj;
            return Equals(_value, other._value);
        }

        public override int GetHashCode() => _value.GetHashCode();
#endregion
    }

    /// <summary>
    /// An immutable object. 
    /// </summary>
    public class Value<T1, T2> : Value<Tuple<T1, T2>>
    {
        protected Value(T1 value1, T2 value2)
            : base(new Tuple<T1, T2>(value1, value2))
        {
        }
        
        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString() => GetType().ToString();
    }

    /// <summary>
    /// An immutable object. 
    /// </summary>
    public class Value<T1, T2, T3> : Value<Tuple<T1, T2, T3>>
    {
        protected Value(T1 value1, T2 value2, T3 value3)
            : base(new Tuple<T1, T2, T3>(value1, value2, value3))
        {
        }

        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString() => GetType().ToString();
    }

    /// <summary>
    /// An immutable object. 
    /// </summary>
    public class Value<T1, T2, T3, T4> : Value<Tuple<T1, T2, T3, T4>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4)
            : base(new Tuple<T1, T2, T3, T4>(value1, value2, value3, value4))
        {
        }

        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString() => GetType().ToString();
    }

    /// <summary>
    /// An immutable object. 
    /// </summary>
    public class Value<T1, T2, T3, T4, T5> : Value<Tuple<T1, T2, T3, T4, T5>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            : base(new Tuple<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5))
        {
        }
        
        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString() => GetType().ToString();
    }

    /// <summary>
    /// An immutable object. 
    /// </summary>
    public class Value<T1, T2, T3, T4, T5, T6> : Value<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            : base(new Tuple<T1, T2, T3, T4, T5, T6>(value1, value2, value3, value4, value5, value6))
        {
        }

        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString() => GetType().ToString();
    }

    /// <summary>
    /// An immutable object. 
    /// </summary>
    public class Value<T1, T2, T3, T4, T5, T6, T7> : Value<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            : base(new Tuple<T1, T2, T3, T4, T5, T6, T7>(value1, value2, value3, value4, value5, value6, value7))
        {
        }

        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString() => GetType().ToString();
    }

    /// <summary>
    /// An immutable object. 
    /// </summary>
    public class Value<T1, T2, T3, T4, T5, T6, T7, T8> : Value<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        protected Value(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
            : base(new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(value1, value2, value3, value4, value5, value6, value7, value8))
        {
        }

        /// <summary>
        /// Creates a new instance of the Value class. Use this constructor to support (de)serialization.
        /// </summary>
        protected Value(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString() => GetType().ToString();
    }
}
