using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.DomainObjects
{
    /// <summary>
    /// An immutable boolean object. 
    /// </summary>
    public class BoolValue : Value<bool>
    {
        private readonly bool _value;

        protected BoolValue(bool value) : base(value)
        {
            _value = value;
        }
        
        /// <summary>
        /// Creates a new instance of the BoolValue class. Use this constructor to support (de)serialization.
        /// </summary>
        protected BoolValue(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var value = info.GetValue("values", typeof(bool));
            _value = value != null && (bool) value;
        }

        public static bool operator ==(BoolValue left, BoolValue right) => AreEqual(left, right);
        public static bool operator !=(BoolValue left, BoolValue right) => !AreEqual(left, right);
        public static bool operator ==(BoolValue left, bool right) => AreEqual(left, right);
        public static bool operator !=(BoolValue left, bool right) => !AreEqual(left, right);
        public static bool operator ==(bool right, BoolValue left) => AreEqual(left, right);
        public static bool operator !=(bool right, BoolValue left) => !AreEqual(left, right);

        private static bool AreEqual(BoolValue a, BoolValue b) => (object.Equals(a, null) && object.Equals(b, null)) 
                                                                    || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b));
        
        private static bool AreEqual(BoolValue a, bool b) => !object.Equals(a, null) && a._value == b;

        public override bool Equals(object obj)
        {
            return obj != null
                   && this.GetType() == obj.GetType()
                   && obj is BoolValue boolValue
                   && boolValue._value == _value;
        }

        public override int GetHashCode()
        {
            var hashCode = 1929208869;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _value.GetHashCode();
            return hashCode;
        }
        
        

        /// <summary>
        /// Converts a boolValue to a boolean
        /// </summary>
        /// <param name="value">The boolvalue to convert</param>
        /// <returns>A boolean value</returns>
        public static implicit operator bool(BoolValue value)
        {
            if(object.Equals(value, null))
            {
                throw new ArgumentNullException(nameof(value), "Cannot convert NULL to a boolean value.");
            }

            return value._value;
        }

        public virtual bool ToBool() => _value;

    }
}