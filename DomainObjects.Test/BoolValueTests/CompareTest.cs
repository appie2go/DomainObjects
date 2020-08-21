using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainDrivenDesign.DomainObjects.Test.BoolValueTests
{
    [TestClass]
    public class CompareTest
    {
        [TestMethod]
        public void WhenLeftNull_ShouldBeFalse()
        {
            // Arrange
            TestableBooleanValue value = null;

            // act
            var actual = value == true;

            // assert
            actual.Should().BeFalse();
        }
        
        [TestMethod]
        public void WhenRightNull_ShouldBeFalse()
        {
            // Arrange
            TestableBooleanValue value = null;

            // act
            var actual = true == value;

            // assert
            actual.Should().BeFalse();
        }
        
        [TestMethod]
        public void WhenTrue_ShouldBeTrue()
        {
            // Arrange
            var input = TestableBooleanValue.Create(true);

            // act
            var actual = (bool) input;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenFalse_ShouldBeFalse()
        {
            // Arrange
            var input = TestableBooleanValue.Create(false);
            
            // act
            var actual = (bool)input;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenComparingBooleanValueTrueToTrue_ShouldBeEqual()
        {
            // arrange
            var a = TestableBooleanValue.Create(true);
            const bool b = true;

            // act
            var actual = a == b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenComparingTrueToBooleanValueTrue_ShouldBeEqual()
        {
            // arrange
            const bool a = true;
            var b = TestableBooleanValue.Create(true);

            // act
            var actual = a == b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenComparingBooleanValueTrueToFalse_ShouldNotBeEqual()
        {
            // arrange
            var a = TestableBooleanValue.Create(true);
            const bool b = false;

            // act
            var actual = a == b;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenComparingFalseToBooleanValueTrue_ShouldNotBeEqual()
        {
            // arrange
            const bool a = false;
            var b = TestableBooleanValue.Create(true);

            // act
            var actual = a == b;

            // assert
            actual.Should().BeFalse();
        }
    }
}
