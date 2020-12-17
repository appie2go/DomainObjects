using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DomainDrivenDesign.DomainObjects.Test.SerializationTest
{
    [TestClass]
    public class BoolValueSerializerTest
    {
        private readonly Fixture _fixture = new Fixture();
        
        [TestMethod]
        public void WhenDeserializingSingleValue_ShouldEqualOriginalValue()
        {
            //  Arrange
            var expected = _fixture.Create<TestableBooleanValue>();
            
            // Act
            var json = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<TestableBooleanValue>(json);

            // Assert
            actual.Should().Be(expected);
        }
    }
}