namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableBooleanValue : BoolValue
    {
        public static TestableBooleanValue Create(bool value)
        {
            return new TestableBooleanValue(value);
        }

        private TestableBooleanValue(bool value) : base(value)
        {
        }
    }
}
