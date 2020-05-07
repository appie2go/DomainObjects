namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableEntityWithIntId : Entity<TestableEntityWithIntId, int>
    {
        public Number Number { get; }

        public static TestableEntityWithIntId Create(IntId id, Number number)
        {
            return new TestableEntityWithIntId(id, number);
        }

        protected TestableEntityWithIntId(IntId id, Number number) : base(id)
        {
            Number = number;
        }
    }
}
