namespace DomainDrivenDesign.DomainObjects.Test
{
    public class AnotherTestableBooleanValue : BoolValue
    {
        public static AnotherTestableBooleanValue Create(bool value)
        {
            return new AnotherTestableBooleanValue(value);
        }

        private AnotherTestableBooleanValue(bool value) : base(value)
        {
        }
    }
}