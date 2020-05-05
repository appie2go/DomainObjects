using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainDrivenDesign.DomainObjects.Test.EntityTests
{
    [TestClass]
    public class EqualityTests
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenSameId_ShouldBeEqual()
        {
            // arrange
            var id = _fixture.Create<Id<TestableEntity>>();
            var a = new TestableEntity(id, _fixture.Create<Name>());
            var b = new TestableEntity(id, _fixture.Create<Name>());

            // act
            var actual = a.Equals(b);

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSameId_ShouldBeEqualObjects()
        {
            // arrange
            var id = _fixture.Create<Id<TestableEntity>>();
            var a = new TestableEntity(id, _fixture.Create<Name>());
            var b = new TestableEntity(id, _fixture.Create<Name>());

            // act
            var actual = a.Equals((object)b);

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSameId_ShouldCompare()
        {
            // arrange
            var id = _fixture.Create<Id<TestableEntity>>();
            var a = new TestableEntity(id, _fixture.Create<Name>());
            var b = new TestableEntity(id, _fixture.Create<Name>());

            // act
            var actual = a == b;

            // assert
            actual.Should().BeTrue();
        }
    }
}
