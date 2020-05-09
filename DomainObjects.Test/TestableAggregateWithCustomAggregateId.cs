namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableAggregateWithCustomAggregateId : Aggregate<TestableAggregateWithCustomAggregateId, CustomAggregateId>
    {
        public Name Name { get; }

        public static TestableAggregateWithCustomAggregateId Create(CustomAggregateId id, Name number)
        {
            return new TestableAggregateWithCustomAggregateId(id, number);
        }

        private TestableAggregateWithCustomAggregateId(CustomAggregateId id, Name number) : base(id)
        {
            Name = number;
        }
    }
}
