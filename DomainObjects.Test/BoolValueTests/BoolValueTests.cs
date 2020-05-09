using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.DomainObjects.Test
{
    [TestClass]
    public class BoolValueTests
    {
        [TestMethod]
        public void WhenTrue_ShouldBeTrue()
        {
            // act
            bool value = TestableBooleanValue.Create(true);

            // assert
            value.Should().BeTrue();
        }

        [TestMethod]
        public void WhenFalse_ShouldBeFalse()
        {
            // act
            bool value = TestableBooleanValue.Create(false);

            // assert
            value.Should().BeFalse();
        }

        [TestMethod]
        public void WhenComparingBooleanValueTrueToTrue_ShouldBeEqual()
        {
            // arrange
            var a = TestableBooleanValue.Create(true);
            var b = true;

            // act
            var actual = a == b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenComparingTrueToBooleanValueTrue_ShouldBeEqual()
        {
            // arrange
            var a = true;
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
            var b = false;

            // act
            var actual = a == b;

            // assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenComparingFalseToBooleanValueTrue_ShouldNotBeEqual()
        {
            // arrange
            var a = false;
            var b = TestableBooleanValue.Create(true);

            // act
            var actual = a == b;

            // assert
            actual.Should().BeFalse();
        }
    }
}
