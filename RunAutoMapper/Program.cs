using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapping;

namespace RunAutoMapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData
            {
                Date = new DateTime(2012, 1, 1),
                TempHigh = 20,
                TempMean = 17, // Intentionally set to something other than 15
                TempLow = 10,
                Rainfall = 17,
                SoilTemp = -1 // Rubbish data to ignore
            };

            var autoMapWeather = new AutoMapWeather();
            var weather = autoMapWeather.WeatherDataToWeather(weatherData);
        }
    }
}
