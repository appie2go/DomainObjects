using DomainObjects.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.DomainObjects.Test
{
    public class TestableEntity : Entity<TestableEntity>
    {
        public Name Number { get; }

        public TestableEntity(Id<TestableEntity> id, Name number) : base(id)
        {
            Number = number;
        }


    }
}
