using AutoMapping.ConfigurationValidation;
using FluentAssertions;
using Xunit;

namespace AutoMappingTests.ConfigurationValidation
{
    public class MatchedMemberMisMatchedTypeTests
    {
        [Fact]
        public void Validate_WithMatchedMembersButMismatchedTypesIgnored_ExpectPassValidation()
        {
            // Arrange
            var matchedMemberMisMatched = new MatchedMemberMisMatchedType();

            // Act
            matchedMemberMisMatched.Validate();

            // Assert
            matchedMemberMisMatched.Exception.Should().BeNull();
        }
    }
}
