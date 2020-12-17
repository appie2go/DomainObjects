using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.DomainObjects.Test
{
    [Serializable]
    public class Number : ComparableValue<int>
    {
        public static Number Create(int value)
        {
            return new Number(value);
        }

        protected Number(int value) : base(value)
        {
        }

        protected Number(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
