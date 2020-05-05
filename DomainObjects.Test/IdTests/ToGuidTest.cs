using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainDrivenDesign.DomainObjects.Test.IdTests
{
    [TestClass]
    public class ToGuidTest
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenValuePassedToConstructor_ShouldBeSame()
        {
            // arrange
            var expected = _fixture.Create<Guid>();
            var id = Id<TestableEntity>.Create(expected);

            // act
            var actual = id.ToGuid();

            // assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void WhenCreateNew_ShouldNotBeEmpty()
        { // arrange
            var id = Id<TestableEntity>.New();

            // act
            var actual = id.ToGuid();

            // assert
            actual.Should().NotBe(Guid.Empty);
        }
    }
}
