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
            var a = Id<TestableEntity>.Create(guid);
            var b = Id<TestableEntity>.Create(guid);

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
            var a = Id<TestableEntity>.Create(guid);
            var list = new List<Id<TestableEntity>>
            {
                Id<TestableEntity>.Create(guid),
                Id<TestableEntity>.Create(_fixture.Create<Guid>()),
                Id<TestableEntity>.Create(_fixture.Create<Guid>())
            };

            // act
            var actual = list.Contains(a);

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenNull_ShouldNotBeEqual()
        {
            // Arrange
            var a = Id<TestableEntity>.Create(Guid.NewGuid());
            
            // Act
            var actual = a == null;
            
            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenNull_ShouldBeUnEqual()
        {
            // Arrange
            var a = Id<TestableEntity>.Create(Guid.NewGuid());
            
            // Act
            var actual = a != null;
            
            // Assert
            actual.Should().BeTrue();
        }
    }
}
