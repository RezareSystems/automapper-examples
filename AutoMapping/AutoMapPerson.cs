using System;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace AutoMapping
{
    public class AutoMapPerson
    {
        public IMapper JsonToPersonMapper;

        /// <summary>
        /// Automapper works best when object properties have matching names.
        /// If each mapping is explicitely specified, the value of automapper is decreased
        /// </summary>
        public AutoMapPerson()
        {
            // The following configuration has multiple mappings, including different ways of doing the same
            // type of conversion. It is used as an example of how to do different conversions
            var config = new MapperConfiguration(cfg =>
            {
                // Anytime a string is mapped to a double, this conversion will be used
                // unless some other conversion is specified
                cfg.CreateMap<string, double>().ConvertUsing(Convert.ToDouble);
                // Map a string to int, due to member overloading, Convert.ToInt32 can't be used by itself
                //cfg.CreateMap<string, int>().ConvertUsing(str => Convert.ToInt32(str));
                cfg.CreateMap<JToken, int?>().ConvertUsing<JTokenToNullableIntConverter>();
                cfg.CreateMap<string, int?>().ConvertUsing<StringToNullableIntConverter>();

                // Unless json["some_element"].ToString() is used,
                // then json["some_element"] will return a JToken
                // Automapper appears to handle simple JToken conversion if no converters are applied
                cfg.CreateMap<JObject, Person>()
                    .ForMember(dest => dest.FirstName, src => src.MapFrom(json => json["first_name"]))
                    .ForMember(dest => dest.LastName, src => src.MapFrom(json => json["last_name"]))
                    .ForMember(dest => dest.Age, src => src.MapFrom(json => json["age"]))
                    .ForMember(dest => dest.NullableAge1, src => src.MapFrom(json => json["age1"])) // uses JTokenToNullableIntConverter
                    .ForMember(dest => dest.NullableAge2, src => src.MapFrom(json => json["age2"].ToString())) // uses StringToNullableIntConverter
                    .ForMember(dest => dest.NullableAge3, src => src.ResolveUsing<NullableIntValueResolver>()) // "age3" is defined in NullableIntValueResolver
                    .ForMember(dest => dest.NullableAge4, src => src.ResolveUsing<NullableIntMemberValueResolver, string>(json => json["age4"].ToString())) // uses NullableIntMemberValueResolver once element has been specified (and converted to a string)
                    .ForAllOtherMembers(opt => opt.Ignore());
            });

            config.AssertConfigurationIsValid();

            JsonToPersonMapper = config.CreateMapper();
        }

        public Person JObjectToPerson(JObject jObject)
        {
            return JsonToPersonMapper.Map<Person>(jObject);
        }

        /// <summary>
        /// The element in json is a JToken not a string.
        /// A string could be used here instead of a JToken if the JToken is converted to a string first
        /// </summary>
        class StringToNullableIntConverter : ITypeConverter<string, int?>
        {
            public int? Convert(string source, int? destination, ResolutionContext context)
            {
                return StringToNullableInt(source);
            }
        }

        class JTokenToNullableIntConverter : ITypeConverter<JToken, int?>
        {
            public int? Convert(JToken source, int? destination, ResolutionContext context)
            {
                return StringToNullableInt(source.ToString());
            }
        }

        class NullableIntValueResolver : IValueResolver<JToken, Person, int?>
        {
            public int? Resolve(JToken source, Person destination, int? destMember, ResolutionContext context)
            {
                var value = source["age3"].ToString();

                return StringToNullableInt(value);
            }
        }

        class NullableIntMemberValueResolver : IMemberValueResolver<JToken, Person, string, int?>
        {
            public int? Resolve(JToken source, Person destination, string sourceMember, int? destMember, ResolutionContext context)
            {
                return StringToNullableInt(sourceMember);
            }
        }

        private static int? StringToNullableInt(string intString)
        {
            int result;
            if (int.TryParse(intString, out result))
            {
                return result;
            }

            return null;
        }

    }
}
