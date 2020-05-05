using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainDrivenDesign.DomainObjects.Test.IdTests
{
    [TestClass]
    public class IdTest
    {
        [TestMethod]
        public void WhenEmptyGuid_ShouldThrowException()
        {
            // act
            Action act = () => Id<TestableEntity>.Create(Guid.Empty);

            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
