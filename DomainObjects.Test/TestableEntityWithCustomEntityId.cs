namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableEntityWithCustomEntityId : Entity<TestableEntityWithCustomEntityId, CustomEntityId>
    {
        public CustomEntityId Id { get; }
        public Number Number { get; }

        public static TestableEntityWithCustomEntityId Create(CustomEntityId id, Number number)
        {
            return new TestableEntityWithCustomEntityId(id, number);
        }

        protected TestableEntityWithCustomEntityId(CustomEntityId id, Number number) : base(id)
        {
            Id = id;
            Number = number;
        }
    }
}
