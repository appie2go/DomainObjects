using DomainDrivenDesign.DomainObjects;

namespace DomainDrivenDesign.DomainObjects
{
    public class BoolValue : Value<bool>
    {
        private readonly bool _value;

        protected BoolValue(bool value) : base(value)
        {
            _value = value;
        }

        public static bool operator ==(BoolValue left, bool right)
        {
            return left?._value == right;
        }

        public static bool operator !=(BoolValue left, bool right)
        {
            return !(left == right);
        }

        public static bool operator ==(bool right, BoolValue left)
        {
            return left == right; // go to the overload
        }

        public static bool operator !=(bool right, BoolValue left)
        {
            return left != right; // go to the overload
        }

        public static implicit operator bool(BoolValue usedForFederation)
        {
            return usedForFederation._value;
        }

        public override bool Equals(object obj)
        {
            return obj is BoolValue value &&
                   base.Equals(obj) &&
                   _value == value._value;
        }

        public override int GetHashCode()
        {
            int hashCode = 1929208869;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _value.GetHashCode();
            return hashCode;
        }
    }
}