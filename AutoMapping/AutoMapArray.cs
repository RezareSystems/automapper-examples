using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapping
{
    public class AutoMapArray
    {
        private readonly IMapper _iMapper;
        public AutoMapArray()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            _iMapper = config.CreateMapper();
        }

        public AutoMapArray(bool includeChildMapping)
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Source, Destination>()
                        .Include<ChildSource, ChildDestination>();
                    cfg.CreateMap<ChildSource, ChildDestination>();
                });

            _iMapper = config.CreateMapper();
        }

        /// <summary>
        /// Map from Array to IEnumerable
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        public IEnumerable<Destination> MapToIEnumerable(Source[] sources)
        {
            return _iMapper.Map<IEnumerable<Destination>>(sources);
        }

        /// <summary>
        /// Map from Array to ICollection
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        public ICollection<Destination> MapToICollection(Source[] sources)
        {
            return _iMapper.Map<ICollection<Destination>>(sources);
        }

        /// <summary>
        /// Map from Array to IList
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        public IList<Destination> MapToIList(Source[] sources)
        {
            return _iMapper.Map<IList<Destination>>(sources);
        }

        /// <summary>
        /// Map from Array to List
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        public List<Destination> MapToList(Source[] sources)
        {
            return _iMapper.Map<List<Destination>>(sources);
        }

        /// <summary>
        /// Map from Array to array
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        public Destination[] MapToArray(Source[] sources)
        {
            return _iMapper.Map<Destination[]>(sources);
        }

        public class Source
        {
            public double Value { get; set; }
        }

        public class Destination
        {
            public double Value { get; set; }
        }

        public class ChildSource : Source
        {
            public double ValueChild { get; set; }
        }

        public class ChildDestination : Destination
        {
            public double ValueChild { get; set; }
        }
    }
}
