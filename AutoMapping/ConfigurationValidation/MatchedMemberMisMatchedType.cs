using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapping.ConfigurationValidation
{
    public class MatchedMemberMisMatchedType
    {
        public AutoMapperConfigurationException Exception;

        public class Source
        {
            public string Foo { get; set; }
            public string Bar { get; set; }
        }

        public class Destination
        {
            public string Foo { get; set; }
            public int Bar { get; set; }
        }

        public void Validate()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Bar, opt => opt.Ignore()));

            try
            {
                Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException exception)
            {
                Exception = exception;
            }
        }
    }
}
