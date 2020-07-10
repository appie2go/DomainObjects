using AutoFixture;
using DomainObjects.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainDrivenDesign.DomainObjects.Test.ValueTests
{
    [TestClass]
    public class ToStringTest
    {
        private static Fixture _fixture = new Fixture();
        
        [TestMethod]
        public void WhenValue_ShouldStringify()
        {
            // arrange
            var expected = _fixture.Create<string>();
            var sut = new TestableValue<string>(expected);
            
            // act
            var actual = sut.ToString();

            // assert
            actual.Should().Be(expected);
        }
        
        [TestMethod]
        public void WhenNull_ShouldReturnNull()
        {
            // arrange
            string expected = null;
            var sut = new TestableValue<string>(expected);
            
            // act
            var actual = sut.ToString();

            // assert
            actual.Should().BeNull();
        }
    }
}