namespace DomainDrivenDesign.DomainObjects.Test
{
    public class IntId : Id<TestableEntityWithIntId, int>
    {
        public static IntId Create(int id)
        {
            return new IntId(id);
        }

        private IntId(int id) : base(id)
        {
        }
    }
}
