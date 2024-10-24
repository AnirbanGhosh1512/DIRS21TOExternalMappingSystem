using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Factory;
using DIRS21ToExternalMapperSystem.Mappers;
using Xunit;

namespace DIRS21ToExternalMapperSystem.Tests
{
    public class MapperFactoryTests
    {
        [Fact]
        public void GetMapper_ValidMapping_ReturnsMapper()
        {
            // Arrange
            var factory = new MapperFactory();

            // Act
            var mapper = factory.GetMapper("DIRS21.Room", "DTO.RoomDTO");

            // Assert
            Assert.NotNull(mapper);
            Assert.IsType<RoomToRoomDTOMapper>(mapper);
        }

        [Fact]
        public void GetMapper_InvalidMapping_ThrowsInvalidMappingException()
        {
            // Arrange
            var factory = new MapperFactory();

            // Act & Assert
            var exception = Assert.Throws<InvalidMappingException>(() => factory.GetMapper("Invalid.Source", "Invalid.Target"));
            Assert.Equal("No mapper found for Invalid.Source to Invalid.Target", exception.Message);
        }
    }

}

