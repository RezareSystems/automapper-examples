using AutoMapper;

namespace AutoMapping.ConfigurationValidation
{
    public class SimpleMatched
    {
        public void Validate()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            config.AssertConfigurationIsValid();
        }

        public class Source
        {
            public int SomeValue { get; set; }
        }

        public class Destination
        {
            public int SomeValue { get; set; }
        }
    }

}
