using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainDrivenDesign.DomainObjects.Test.ComparableValueTests
{
    [TestClass]
    public class CompareToTest
    {
        private readonly Fixture _fixture = new Fixture();

        [TestMethod]
        public void WhenSmaller_SmallerThanShouldReturnTrue()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(0 - value);
            var b = Number.Create(value);

            // act
            var actual = a < b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSmaller_GreaterThanShouldReturnFalse()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(0 - value);
            var b = Number.Create(value);

            // act
            var actual = a > b;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenGreater_SmallerThanShouldReturnFalse()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(value);
            var b = Number.Create(0 - value);

            // act
            var actual = a < b;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenGreater_GreaterThanShouldReturnTrue()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(value);
            var b = Number.Create(0 - value);

            // act
            var actual = a > b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenEqual_SmallerThanShouldReturnFalse()
        {
            // arrange
            var a = Number.Create(_fixture.Create<int>());

            // act
            var actual = a < a;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenEqual_GreaterThanShouldReturnFalse()
        {
            // arrange
            var a = Number.Create(_fixture.Create<int>());

            // act
            var actual = a > a;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenSmaller_SmallerThanOrEqualShouldReturnTrue()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(0 - value);
            var b = Number.Create(value);

            // act
            var actual = a <= b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenSmaller_GreaterThanOrEqualShouldReturnFalse()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(0 - value);
            var b = Number.Create(value);

            // act
            var actual = a >= b;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenGreater_SmallerThanOrEqualShouldReturnFalse()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(value);
            var b = Number.Create(0 - value);

            // act
            var actual = a <= b;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenGreater_GreaterThanOrEqualShouldReturnTrue()
        {
            // arrange
            var value = _fixture.Create<int>();
            var a = Number.Create(value);
            var b = Number.Create(0 - value);

            // act
            var actual = a >= b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenEqual_SmallerThanOrEqualShouldReturnTrue()
        {
            // arrange
            var a = Number.Create(_fixture.Create<int>());

            // act
            var actual = a <= a;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenEqual_GreaterThanOrEqualShouldReturnTrue()
        {
            // arrange
            var a = Number.Create(_fixture.Create<int>());

            // act
            var actual = a >= a;

            // assert
            actual.Should().BeTrue();
        }
    }
}
