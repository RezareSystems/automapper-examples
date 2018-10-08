/*
 Projection transforms a source to a destination beyond flattening the object model. 
 Without extra configuration, AutoMapper requires a flattened destination to match the
 source type’s naming structure. When you want to project source values into a destination 
 that does not exactly match the source structure, you must specify custom member mapping definitions. 
 */

using System;
using AutoMapper;

namespace AutoMapping
{
    public class AutoMapProjection
    {
        public CalenderEventForm Map(CalenderEvent calenderEvent)
        {
            var config = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<CalenderEvent, CalenderEventForm>()
                        .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
                        .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                        .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute)));
            var iMapper = config.CreateMapper();

            CalenderEventForm form = iMapper.Map<CalenderEvent, CalenderEventForm>(calenderEvent);

            return form;
        }
    }

    public class CalenderEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }

    public class CalenderEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }
}