namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableEntity : Entity<TestableEntity>
    {
        public Name Name { get; }

        public static TestableEntity Create(Id<TestableEntity> id, Name number)
        {
            return new TestableEntity(id, number);
        }
        
        private TestableEntity(Id<TestableEntity> id, Name number) : base(id)
        {
            Name = number;
        }
    }
}
