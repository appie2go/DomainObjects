namespace DomainDrivenDesign.DomainObjects.Test
{
    public class CustomEntityId : Id<TestableEntityWithCustomEntityId, int>
    {
        public static CustomEntityId Create(int id)
        {
            return new CustomEntityId(id);
        }

        private CustomEntityId(int id) : base(id)
        {
        }
    }
}
