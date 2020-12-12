using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.DomainObjects.Test
{
    [Serializable]
    public class TestableValue<T> : Value<T>
    {
        public TestableValue(T value) : base(value)
        {
        }

        protected TestableValue(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class TestableValue<T1, T2> : Value<T1, T2>
    {
        public TestableValue(T1 value1, T2 value2) : base(value1, value2)
        {
        }

        protected TestableValue(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
