using AutoMapping;
using FluentAssertions;
using Xunit;

namespace AutoMappingTests
{
    public class AutoMapArrayTests
    {
        [Fact]
        public void MapToIEnumerable_MultipleSourceValues_DestinationValuesShouldMatch()
        {
            // Arrange
            var autoMapArray = new AutoMapArray();
            var sources = ConstructSources();
            
            // Act
            var result = autoMapArray.MapToIEnumerable(sources);

            // Assert
            result.ShouldBeEquivalentTo(sources);
        }

        [Fact]
        public void MapToICollection_MultipleSourceValues_DestinationValuesShouldMatch()
        {
            // Arrange
            var autoMapArray = new AutoMapArray();
            var sources = ConstructSources();

            // Act
            var result = autoMapArray.MapToICollection(sources);

            // Assert
            result.ShouldBeEquivalentTo(sources);
        }

        [Fact]
        public void MapToIList_MultipleSourceValues_DestinationValuesShouldMatch()
        {
            // Arrange
            var autoMapArray = new AutoMapArray();
            var sources = ConstructSources();

            // Act
            var result = autoMapArray.MapToIList(sources);

            // Assert
            result.ShouldBeEquivalentTo(sources);
        }

        [Fact]
        public void MapToList_MultipleSourceValues_DestinationValuesShouldMatch()
        {
            // Arrange
            var autoMapArray = new AutoMapArray();
            var sources = ConstructSources();

            // Act
            var result = autoMapArray.MapToList(sources);

            // Assert
            result.ShouldBeEquivalentTo(sources);
        }

        [Fact]
        public void MapToArray_MultipleSourceValues_DestinationValuesShouldMatch()
        {
            // Arrange
            var autoMapArray = new AutoMapArray();
            var sources = ConstructSources();

            // Act
            var result = autoMapArray.MapToArray(sources);

            // Assert
            result.ShouldBeEquivalentTo(sources);
        }

        [Fact]
        public void MapToArray_PolymorphicElementTypesInCollections_DestinationValuesShouldMatch()
        {
            // Arrange
            var autoMapArray = new AutoMapArray(includeChildMapping:true);
            var sources = new[]
            {
                new AutoMapArray.Source{Value = 3}, 
                new AutoMapArray.ChildSource {ValueChild = 4},
                new AutoMapArray.Source {Value = 5}, 
            };


            // Act
            var destinations = autoMapArray.MapToArray(sources);

            // Assert
            destinations[0].ShouldBeEquivalentTo(sources[0]);
            destinations[1].ShouldBeEquivalentTo(sources[1]);
            destinations[2].ShouldBeEquivalentTo(sources[2]);
        }

        private AutoMapArray.Source[] ConstructSources()
        {
            var sources = new[]
            {
                new AutoMapArray.Source {Value = 5.5},
                new AutoMapArray.Source {Value = 6.6}
            };

            return sources;
        }
    }
}
