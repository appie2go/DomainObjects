using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.DomainObjects.Test
{
    [Serializable]
    public class TestableBooleanValue : BoolValue
    {
        public static TestableBooleanValue Create(bool value)
        {
            return new TestableBooleanValue(value);
        }

        protected TestableBooleanValue(bool value) : base(value)
        {
        }

        protected TestableBooleanValue(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
