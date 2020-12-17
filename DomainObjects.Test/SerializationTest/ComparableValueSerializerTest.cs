using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DomainDrivenDesign.DomainObjects.Test.SerializationTest
{
    [TestClass]
    public class ComparableValueSerializerTest
    {
        private readonly Fixture _fixture = new Fixture();
        
        [TestMethod]
        public void WhenDeserializingSingleValue_ShouldEqualOriginalValue()
        {
            //  Arrange
            var expected = _fixture.Create<Number>();
            
            // Act
            var json = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<Number>(json);

            // Assert
            actual.Should().Be(expected);
        }
    }
}