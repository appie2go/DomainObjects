using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.DomainObjects.Test
{
    [Serializable]
    public class CustomEntityId : Id<TestableEntityWithCustomEntityId, int>
    {
        public static CustomEntityId Create(int id)
        {
            return new CustomEntityId(id);
        }

        private CustomEntityId(int id) : base(id)
        {
        }

        protected CustomEntityId(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
