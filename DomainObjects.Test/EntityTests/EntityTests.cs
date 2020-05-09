using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainDrivenDesign.DomainObjects.Test.EntityTests
{
    [TestClass]
    public class EntityTests
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenGuidId_ShouldContainGuidId()
        {
            // arrange
            var expected = _fixture.Create<Guid>();
            var id = Id<TestableEntity>.Create(expected);
            var name = _fixture.Create<Name>();

            // act
            var actual = TestableEntity.Create(id, name);

            // assert
            actual.Id
                .ToString()
                .Should()
                .Be(expected.ToString());
        }

        [TestMethod]
        public void WhenGuidId_ShouldBeOfTypeId_Key()
        {
            // arrange
            var expected = _fixture.Create<Guid>();
            var id = Id<TestableEntity>.Create(expected);
            var name = _fixture.Create<Name>();

            // act
            var actual = TestableEntity.Create(id, name);

            // assert
            actual.Id
                .Should()
                .BeOfType<Id<TestableEntity>>();
        }

        [TestMethod]
        public void WhenIntId_ShouldContainIntId()
        {
            // arrange
            var expected = _fixture.Create<int>();
            var id = CustomEntityId.Create(expected);
            var number = _fixture.Create<Number>();

            // act
            var actual = TestableEntityWithCustomEntityId.Create(id, number);

            // assert
            actual.Id
                .ToString()
                .Should()
                .Be(expected.ToString());
        }
    }
}
