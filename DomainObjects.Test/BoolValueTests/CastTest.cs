using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainDrivenDesign.DomainObjects.Test.BoolValueTests
{
    [TestClass]
    public class CastTest
    {
        [TestMethod]
        public void WhenNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            TestableBooleanValue value = null;
            
            // Act
            Action act = () =>
            {
                var x = (bool) value;
            };
            
            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("Cannot convert NULL to a boolean value. (Parameter 'value')");
        }

        [TestMethod]
        public void WhenTrue_ShouldCastToTrue()
        {
            // Arrange
            var value = TestableBooleanValue.Create(true);
            
            // Act
            var actual = (bool) value;
            
            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenFalse_ShouldCastToTrue()
        {
            // Arrange
            var value = TestableBooleanValue.Create(true);
            
            // Act
            var actual = (bool) value;
            
            // Assert
            actual.Should().BeTrue();
        }
    }
}