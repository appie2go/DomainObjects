namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableAggregate : Aggregate<TestableAggregate>
    {
        public Name Name { get; }

        public static TestableAggregate Create(Id<TestableAggregate> id, Name number)
        {
            return new TestableAggregate(id, number);
        }

        private TestableAggregate(Id<TestableAggregate> id, Name number) : base(id)
        {
            Name = number;
        }
    }
}
