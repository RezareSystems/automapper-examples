using AutoMapping.ConfigurationValidation;
using Xunit;

namespace AutoMappingTests.ConfigurationValidation
{
    public class SimpleMatchedTests
    {
        [Fact]
        public void Validate_MapFromSourceModelToTargetModel_ExpectValid()
        {
            // Arrange
            var configurationValidation = new SimpleMatched();

            // Act
            configurationValidation.Validate();
        }
    }
}
