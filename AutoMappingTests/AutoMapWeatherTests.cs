using System;
using Xunit;
using FluentAssertions;
using AutoMapping;

namespace AutoMappingTests
{
    public class AutoMapWeatherTests
    {
        [Fact]
        public void AutoMapTest()
        {
            // Arrange
            var weatherData = new WeatherData
            {
                Date = new DateTime(2012, 1, 1),
                TempHigh = 20,
                TempMean = 17, // Intentionally set to something other than 15
                TempLow = 10,
                Rainfall = 17,
                SoilTemp = -1 // Rubbish data to ignore
            };

            var expected = new Weather
            {
                Date = weatherData.Date,
                TempMax = weatherData.TempHigh,
                TempMin = weatherData.TempLow,
                Rainfall = weatherData.Rainfall,
                SoilTemp = 0
            };

            // Act
            var autoMapWeather = new AutoMapWeather();
            var calculated = autoMapWeather.WeatherDataToWeather(weatherData);

            // Assert
            calculated.ShouldBeEquivalentTo(expected);

        }
    }
}
