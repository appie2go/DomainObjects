using System;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DomainDrivenDesign.DomainObjects.Test.SerializationTest
{
    [TestClass]
    public class ValueTypeJsonSerializerTest
    {
        private readonly Fixture _fixture = new Fixture();
        
        [TestMethod]
        public void WhenDeserializingSingleValue_ShouldEqualOriginalValue()
        {
            //  Arrange
            var expected = _fixture.Create<TestableValue<string>>();
            
            // Act
            var json = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<TestableValue<string>>(json);

            // Assert
            actual.Should().Be(expected);
        }
        
        [TestMethod]
        public void WhenDeserializingMultipleValue_ShouldEqualOriginalValue()
        {
            //  Arrange
            var expected = _fixture.Create<TestableValue<string, Guid>>();
            
            // Act
            var json = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<TestableValue<string, Guid>>(json);

            // Assert
            actual.Should().Be(expected);
        }
    }
}