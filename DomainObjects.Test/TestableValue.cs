using DomainDrivenDesign.DomainObjects;

namespace DomainObjects.Test
{
    public class TestableValue<T> : Value<T>
    {
        public TestableValue(T value) : base(value)
        {
        }
    }

    public class TestableValue<T1, T2> : Value<T1, T2>
    {
        public TestableValue(T1 value1, T2 value2) : base(value1, value2)
        {
        }
    }
}
