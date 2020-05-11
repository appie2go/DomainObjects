using System;

namespace DomainDrivenDesign.DomainObjects.Test
{

    public class CustomAggregateId : Id<TestableAggregateWithCustomAggregateId, Guid>
    {
        public static CustomAggregateId Create(Guid id) => new CustomAggregateId(id);

        public static CustomAggregateId New() => new CustomAggregateId(Guid.NewGuid());

        private CustomAggregateId(Guid id) : base(id)
        {
        }
    }

}
