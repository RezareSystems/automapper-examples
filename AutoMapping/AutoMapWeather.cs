using AutoMapper;

namespace AutoMapping
{
    public class AutoMapWeather
    {
        public IMapper WeatherMapper;

        public AutoMapWeather()
        {
            // Create a map from WeatherData to Weather
            var config = new MapperConfiguration(cfg =>
            {
                // The ForMember extensions are used to change the mapped properties or
                // add conditions. If these aren't necessary, just use CreateMap.
                cfg.CreateMap<WeatherData, Weather>()
                    .ForMember(dest => dest.TempMax, src => src.MapFrom(prop => prop.TempHigh))
                    .ForMember(dest => dest.TempMin, src => src.MapFrom(prop => prop.TempLow))
                    .ForMember(src => src.SoilTemp, opt => opt.Ignore()); // Ignore the SoilTemp mapping
            });

            WeatherMapper = config.CreateMapper();
        }

        public Weather WeatherDataToWeather(WeatherData weatherData)
        {
            // Both of these do the same thing:
            // WeatherMapper.Map<WeatherData, Weather>(weatherData); // This explicitely states the source type
            // WeatherMapper.Map<Weather>(weatherData); // this infers the source type from the passed in object
            var weather = WeatherMapper.Map<Weather>(weatherData);

            return weather;
        }

    }
}
