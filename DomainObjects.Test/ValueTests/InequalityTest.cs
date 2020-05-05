using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainObjects.Test.ValueTests
{
    [TestClass]
    public class InequalityTest
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenDifferentValue_ShouldNotEqual()
        {
            // arrange
            var a = new TestableValue<string>(_fixture.Create<string>());
            var b = new TestableValue<string>(_fixture.Create<string>());

            // act
            var actual = a.Equals(b);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenDifferentValues_ShouldNotEqual()
        {
            // arrange
            var value1 = _fixture.Create<string>();
            var a = new TestableValue<string, string>(value1, _fixture.Create<string>());
            var b = new TestableValue<string, string>(value1, _fixture.Create<string>());

            // act
            var actual = a.Equals(b);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenDifferentValue_ShouldNotEqualObject()
        {
            // arrange
            var a = new TestableValue<string>(_fixture.Create<string>());
            var b = new TestableValue<string>(_fixture.Create<string>());

            // act
            var actual = a.Equals((object)b);

            // Assert
            actual.Should().BeFalse();
        }


        [TestMethod]
        public void WhenDifferentValues_ShouldNotEqualObject()
        {
            // arrange
            var value1 = _fixture.Create<string>();
            var a = new TestableValue<string, string>(value1, _fixture.Create<string>());
            var b = new TestableValue<string, string>(value1, _fixture.Create<string>());

            // act
            var actual = a.Equals((object)b);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenDifferentValue_ShouldNotCompare()
        {
            // arrange
            var a = new TestableValue<string>(_fixture.Create<string>());
            var b = new TestableValue<string>(_fixture.Create<string>());

            // act
            var actual = a == b;

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenDifferentValue_ShouldBeUnequal()
        {
            // arrange
            var a = new TestableValue<string>(_fixture.Create<string>());
            var b = new TestableValue<string>(_fixture.Create<string>());

            // act
            var actual = a != b;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenDifferentValues_ShouldBeUnequal()
        {
            // arrange
            var value1 = _fixture.Create<string>();
            var a = new TestableValue<string, string>(value1, _fixture.Create<string>());
            var b = new TestableValue<string, string>(value1, _fixture.Create<string>());

            // act
            var actual = a != b;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenComparingToNull_ShouldBeUnequal()
        {
            // arrange
            var a = new TestableValue<string>(_fixture.Create<string>());
            TestableValue<string> b = null;

            // act
            var actual = a == b;

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenComparingNullToNull_ShouldBeUnequal()
        {
            // arrange
            TestableValue<string> a = null;
            TestableValue<string> b = null;

            // act
            var actual = a == b;

            // Assert
            actual.Should().BeTrue();
        }
    }
}
