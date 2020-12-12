using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DomainDrivenDesign.DomainObjects.Test.SerializationTest
{
    [TestClass]
    public class IdJsonSerializerTest
    {
        private readonly Fixture _fixture = new Fixture();
        
        [TestMethod]
        public void WhenDeserializing_ShouldEqualOriginalValue()
        {
            //  Arrange
            var expected = _fixture.Create<Id<TestableEntity>>();
            
            // Act
            var json = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<Id<TestableEntity>>(json);

            // Assert
            actual.Should().Be(expected);
        }
        
        [TestMethod]
        public void WhenDeserializingCustomId_ShouldEqualOriginalValue()
        {
            //  Arrange
            var expected = _fixture.Create<CustomEntityId>();
            
            // Act
            var json = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<CustomEntityId>(json);

            // Assert
            actual.Should().Be(expected);
        }
    }
}