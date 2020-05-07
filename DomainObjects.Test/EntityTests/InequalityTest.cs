using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainDrivenDesign.DomainObjects.Test.EntityTests
{
    [TestClass]
    public class InequalityTest
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenDifferentId_ShouldNotBeEqual()
        {
            // arrange
            var number = _fixture.Create<Name>();
            var a = TestableEntity.Create(_fixture.Create<Id<TestableEntity>>(), number);
            var b = TestableEntity.Create(_fixture.Create<Id<TestableEntity>>(), number);

            // act
            var actual = a.Equals(b);

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenDifferentId_ShouldNotCompare()
        {
            // arrange
            var number = _fixture.Create<Name>();
            var a = TestableEntity.Create(_fixture.Create<Id<TestableEntity>>(), number);
            var b = TestableEntity.Create(_fixture.Create<Id<TestableEntity>>(), number);

            // act
            var actual = a == b;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenDifferentId_ShouldCompareShouldNotBeTrue()
        {
            // arrange
            var number = _fixture.Create<Name>();
            var a = TestableEntity.Create(_fixture.Create<Id<TestableEntity>>(), number);
            var b = TestableEntity.Create(_fixture.Create<Id<TestableEntity>>(), number);

            // act
            var actual = a != b;

            // assert
            actual.Should().BeTrue();
        }
    }
}
