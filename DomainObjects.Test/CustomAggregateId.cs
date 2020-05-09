using System;

namespace DomainDrivenDesign.DomainObjects.Test
{

    public class CustomAggregateId : Id<TestableAggregateWithCustomAggregateId, Guid>
    {
        protected CustomAggregateId(Guid id) : base(id)
        {
        }
    }
}
