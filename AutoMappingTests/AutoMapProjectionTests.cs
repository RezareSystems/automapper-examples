using System;
using AutoMapping;
using FluentAssertions;
using Xunit;

namespace AutoMappingTests
{
    public class AutoMapProjectionTests
    {
        [Fact]
        public void Map_FromCalendarEventToForm_ReturnCorrectedValues()
        {
            // Arrange
            var calenderEvent = new CalenderEvent
            {
                Date = new DateTime(2018, 08, 31, 17, 35, 54),
                Title = "Friday party"
            };

            var projection = new AutoMapProjection();
            
            // Act
            var result = projection.Map(calenderEvent);

            // Assert
            result.EventDate.Should().Be(new DateTime(2018, 08, 31));
            result.EventHour.Should().Be(17);
            result.EventMinute.Should().Be(35);
            result.Title.Should().Be("Friday party");
        }
    }
}
