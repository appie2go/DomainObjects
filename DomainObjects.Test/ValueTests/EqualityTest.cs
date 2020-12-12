using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainObjects.Test.ValueTests
{
    [TestClass]
    public class EqualityTest
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenSameReference_ShouldEqual()
        {
            // arrange
            var a = new TestableValue<string>(_fixture.Create<string>());

            // act
            var actual = a == a;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSameValue_ShouldEqual()
        {
            // arrange
            var value = _fixture.Create<string>();
            var a = new TestableValue<string>(value);
            var b = new TestableValue<string>(value);

            // act
            var actual = a.Equals(b);

            // Assert
            actual.Should().BeTrue();
        }
        
        [TestMethod]
        public void WhenNull_ShouldNotEqual()
        {
            // arrange
            var value = _fixture.Create<string>();
            var a = new TestableValue<string>(value);
            
            // act
            var actual = a == null;

            // Assert
            actual.Should().BeFalse();
        }
        
        [TestMethod]
        public void WhenSameValues_ShouldEqual()
        {
            // arrange
            var value1 = _fixture.Create<string>();
            var value2 = _fixture.Create<string>();
            var a = new TestableValue<string, string>(value1, value2);
            var b = new TestableValue<string, string>(value1, value2);

            // act
            var actual = a.Equals(b);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSameValue_ShouldEqualObject()
        {
            // arrange
            var value = _fixture.Create<string>();
            var a = new TestableValue<string>(value);
            var b = new TestableValue<string>(value);

            // act
            var actual = a.Equals((object)b);

            // Assert
            actual.Should().BeTrue();
        }


        [TestMethod]
        public void WhenSameValues_ShouldEqualObject()
        {
            // arrange
            var value1 = _fixture.Create<string>();
            var value2 = _fixture.Create<string>();
            var a = new TestableValue<string, string>(value1, value2);
            var b = new TestableValue<string, string>(value1, value2);

            // act
            var actual = a.Equals((object)b);

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSameValue_ShouldCompare()
        {
            // arrange
            var value = _fixture.Create<string>();
            var a = new TestableValue<string>(value);
            var b = new TestableValue<string>(value);

            // act
            var actual = a == b;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSameValues_ShouldCompare()
        {
            // arrange
            var value1 = _fixture.Create<string>();
            var value2 = _fixture.Create<string>();
            var a = new TestableValue<string, string>(value1, value2);
            var b = new TestableValue<string, string>(value1, value2);

            // act
            var actual = a == b;

            // Assert
            actual.Should().BeTrue();
        }
    }
}
