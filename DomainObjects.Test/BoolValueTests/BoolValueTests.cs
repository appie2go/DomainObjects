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
            bool value = TestBooleanValue.Create(true);

            // assert
            value.Should().BeTrue();
        }

        [TestMethod]
        public void WhenFalse_ShouldBeFalse()
        {
            // act
            bool value = TestBooleanValue.Create(false);

            // assert
            value.Should().BeFalse();
        }

        [TestMethod]
        public void WhenComparingBooleanValueTrueToTrue_ShouldBeEqual()
        {
            // arrange
            var a = TestBooleanValue.Create(true);
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
            var b = TestBooleanValue.Create(true);

            // act
            var actual = a == b;

            // assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenComparingBooleanValueTrueToFalse_ShouldNotBeEqual()
        {
            // arrange
            var a = TestBooleanValue.Create(true);
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
            var b = TestBooleanValue.Create(true);

            // act
            var actual = a == b;

            // assert
            actual.Should().BeFalse();
        }
    }
}
