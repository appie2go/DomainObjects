namespace DomainDrivenDesign.DomainObjects.Test
{
    public class Number : ComparableValue<int>
    {
        public static Number Create(int value)
        {
            return new Number(value);
        }

        private Number(int value) : base(value)
        {
        }
    }
}
