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
        public void WhenLeftNullRightNotNull_ShouldBeTrue()
        {
            // Arrange
            var b = TestableBooleanValue.Create(true);

            // act
            var actual = null == b;

            // assert
            actual.Should().BeFalse();
        }
        
        [TestMethod]
        public void WhenLeftNotNullRightNull_ShouldBeFalse()
        {
            // Arrange
            var a = TestableBooleanValue.Create(true);

            // act
            var actual = a == null;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenObjectOfDifferentBooleanValueType_ShouldBeFalse()
        {
            // Arrange
            var a = TestableBooleanValue.Create(true);
            var b = AnotherTestableBooleanValue.Create(true);
            
            // Act
            var actual = a == b;

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenObjectOfDifferentBooleanValueType_ShouldBeTrue()
        {
            // Arrange
            var a = TestableBooleanValue.Create(true);
            var b = AnotherTestableBooleanValue.Create(true);
            
            // Act
            var actual = a != b;

            // Assert
            actual.Should().BeTrue();
        }
        
        [TestMethod]
        public void WhenObjectOfDifferentType_ShouldBeFalse()
        {
            // Arrange
            var a = TestableBooleanValue.Create(true);
            var b = new object();
            
            // Act
            var actual = a == b;

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenObjectOfDifferentType_ShouldBeTrue()
        {
            // Arrange
            var a = TestableBooleanValue.Create(true);
            var b = new object();
            
            // Act
            var actual = a != b;

            // Assert
            actual.Should().BeTrue();
        }


        [TestMethod]
        public void WhenLeftNullRightNotNull_ShouldBeFalse()
        {
            // Arrange
            TestableBooleanValue a = null;

            // act
            var actual = a != null;

            // assert
            actual.Should().BeFalse();
        }
        
        [TestMethod]
        public void WhenLeftNotNullRightNull_ShouldBeTrue()
        {
            // Arrange
            var a = TestableBooleanValue.Create(true);

            // act
            var actual = a != null;

            // assert
            actual.Should().BeTrue();
        }
        
        [TestMethod]
        public void WhenTrue_ShouldBeTrue()
        {
            // Arrange
            var input = TestableBooleanValue.Create(true);

            // act
            bool actual = input;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenFalse_ShouldBeFalse()
        {
            // Arrange
            var input = TestableBooleanValue.Create(false);
            
            // act
            bool actual = input;

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
