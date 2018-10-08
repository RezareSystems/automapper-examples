using AutoMapper;

namespace AutoMapping.ConfigurationValidation
{
    public class ArrayTypeMismatchedElementType
    {
        public AutoMapperConfigurationException Exception;

        public class Source
        {
            public SourceItem[] Items;
        }

        public class Destination
        {
            public DestinationItem[] Items;
        }

        public class SourceItem
        {
            public int Item { get; set; }
        }

        public class DestinationItem
        {
            public string Item { get; set; }
        }

        public void Map()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>();
                cfg.CreateMissingTypeMaps = false;
            });

            try
            {
                config.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException exception)
            {
                Exception = exception;
            }
        }
    }
}
