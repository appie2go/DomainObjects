using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesign.DomainObjects.Test.IdTests
{
    [TestClass]
    public class EqualityTest
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenSameValues_ShouldBeComparable()
        {
            // arrange
            var guid = _fixture.Create<Guid>();
            var a = new Id<TestableEntity>(guid);
            var b = new Id<TestableEntity>(guid);

            // act
            Action act = () => a.Should().Be(b);

            // assert
            act.Should().NotThrow<Exception>();
        }

        [TestMethod]
        public void WhenInList_ShouldContain()
        {
            // arrange
            var guid = _fixture.Create<Guid>();
            var a = new Id<TestableEntity>(guid);
            var list = new List<Id<TestableEntity>>
            {
                new Id<TestableEntity>(guid),
                new Id<TestableEntity>(_fixture.Create<Guid>()),
                new Id<TestableEntity>(_fixture.Create<Guid>())
            };

            // act
            var actual = list.Contains(a);

            // assert
            actual.Should().BeTrue();
        }
    }
}
