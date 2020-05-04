using DomainObjects.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableEntity : Entity<TestableEntity>
    {
        public Number Number { get; }

        public TestableEntity(Id<TestableEntity> id, Number number) : base(id)
        {
            Number = number;
        }


    }
}
