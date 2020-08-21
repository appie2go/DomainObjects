using System;

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

        public static bool operator ==(BoolValue left, bool right) => AreEqual(left, right);

        public static bool operator !=(BoolValue left, bool right) => !AreEqual(left, right);

        public static bool operator ==(bool right, BoolValue left) => AreEqual(left, right);

        public static bool operator !=(bool right, BoolValue left) => !AreEqual(left, right);

        private static bool AreEqual(BoolValue a, bool b) => a != null && a._value == b;

        public override bool Equals(object obj)
        {
            return obj != null
                   && obj is BoolValue boolValue
                   && boolValue._value == _value;
        }

        public override int GetHashCode()
        {
            int hashCode = 1929208869;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _value.GetHashCode();
            return hashCode;
        }
        
        

        /// <summary>
        /// Converts a boolValue to a boolean
        /// </summary>
        /// <param name="value">The boolvalue to convert</param>
        /// <returns>A boolean value</returns>
        public static explicit operator bool(BoolValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Cannot convert NULL to a boolean value.");
            }

            return value.ToBool();
        }

        public virtual bool ToBool() => _value;

    }
}