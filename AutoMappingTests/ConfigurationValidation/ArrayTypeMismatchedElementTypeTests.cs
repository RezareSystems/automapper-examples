using AutoMapping.ConfigurationValidation;
using FluentAssertions;
using Xunit;

namespace AutoMappingTests.ConfigurationValidation
{
    public class ArrayTypeMismatchedElementTypeTests
    {
        [Fact]
        public void Map_DtoWithArrayTypesWithMisMatchedTypes_ShouldFailValidation()
        {
            // Arrange
            var arrayTypeWithMisMatchedType = new ArrayTypeMismatchedElementType();

            // Act
            arrayTypeWithMisMatchedType.Map();

            // Assert
            arrayTypeWithMisMatchedType.Exception.Should().NotBeNull();           
        }
    }
}
