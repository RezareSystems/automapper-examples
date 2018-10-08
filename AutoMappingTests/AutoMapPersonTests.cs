using System;
using Xunit;
using FluentAssertions;
using AutoMapping;
using Newtonsoft.Json.Linq;

namespace AutoMappingTests
{
    public class AutoMapPersonTests
    {
        [Fact]
        public void AutoMapJsonToPerson_AllElementsCorrectlyConverted()
        {
            // Arrange
            var jsonData = "{" +
                           "'first_name':'John'," +
                           "'last_name':'Smith'," +
                           "'age':42," +
                           "'age1':''," +
                           "'age2':null," +
                           "'age3':34," +
                           "'age4':'17'," +
                           "}";
            var jsonObj = JObject.Parse(jsonData);

            // Note, if the jsonData is wrapped in brackets, eg:
            // "[{'first_name':'John'}]"
            // then this is deemed a JsonArray, so instead use
            // JArray.Parse(jsonData);
            // JToken.Parse may also work, but hasn't been tested.

            var expected = new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 42,
                NullableAge1 = null,
                NullableAge2 = null,
                NullableAge3 = 34,
                NullableAge4 = 17
            };

            // Act
            var autoMapPerson = new AutoMapPerson();
            var result = autoMapPerson.JObjectToPerson(jsonObj);

            // Assert
            result.ShouldBeEquivalentTo(expected);
        }
    }
}
