using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainDrivenDesign.DomainObjects.Test.BoolValueTests
{
    [TestClass]
    public class ToBoolTest
    {
        [TestMethod]
        public void WhenTrue_ShouldCastToTrue()
        {
            // Arrange
            var value = TestableBooleanValue.Create(true);
            
            // Act
            var actual = value.ToBool();
            
            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenFalse_ShouldCastToTrue()
        {
            // Arrange
            var value = TestableBooleanValue.Create(true);
            
            // Act
            var actual = value.ToBool();
            
            // Assert
            actual.Should().BeTrue();
        }
    }
}