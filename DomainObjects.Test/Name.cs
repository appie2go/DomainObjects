namespace DomainDrivenDesign.DomainObjects.Test
{
    public class Name : Value<string>
    {
        public static Name Create(string value)
        {
            return new Name(value);
        }

        private Name(string value) : base(value)
        {
        }
    }
}
