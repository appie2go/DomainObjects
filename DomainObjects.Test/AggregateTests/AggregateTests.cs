using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainDrivenDesign.DomainObjects.Test.AggregateTests
{
    [TestClass]
    public class AggregateTests
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenGuidId_ShouldBeOfTypeId_Key()
        {
            // arrange
            var expected = _fixture.Create<Guid>();
            var id = Id<TestableAggregate>.Create(expected);
            var name = _fixture.Create<Name>();

            // act
            var actual = TestableAggregate.Create(id, name);

            // assert
            actual.Id
                .Should()
                .BeOfType<Id<TestableAggregate>>();
        }

        [TestMethod]
        public void WhenCustomId_ShouldBeOfCustomIdType_Key()
        {
            // arrange
            var expected = _fixture.Create<Guid>();
            var id = CustomAggregateId.Create(expected);
            var name = _fixture.Create<Name>();

            // act
            var actual = TestableAggregateWithCustomAggregateId.Create(id, name);

            // assert
            actual.Id
                .Should()
                .BeOfType<CustomAggregateId>();
        }
    }
}
