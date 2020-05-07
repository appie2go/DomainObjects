using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestBooleanValue : BoolValue
    {
        public static TestBooleanValue Create(bool value)
        {
            return new TestBooleanValue(value);
        }

        private TestBooleanValue(bool value) : base(value)
        {
        }
    }
}
