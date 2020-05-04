using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainDrivenDesign.DomainObjects.Test.IdTests
{
    [TestClass]
    public class ToStringTest
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenValuePassedToConstructor_ShouldReturnConstructorValueAsString()
        {
            // arrange
            var expected = _fixture.Create<Guid>();
            var id = new Id<TestableEntity>(expected);

            // act
            var actual = id.ToString();

            // assert
            actual.Should().Be(expected.ToString());
        }
    }
}
