using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Mappers;
using DIRS21ToExternalMapperSystem.Models.DTO;
using Xunit;

namespace DIRS21ToExternalMapperSystem.Tests
{

    public class RoomToRoomDTOMapperTests
    {
        [Fact]
        public void Map_ValidRoom_ReturnsRoomDTO()
        {
            // Arrange
            var mapper = new RoomToRoomDTOMapper();
            var room = new Models.DIRS21Models.Room
            {
                RoomId = "ROOM-001",
                RoomType = "Deluxe",
                Capacity = 2
            };

            // Act
            var result = mapper.Map(room) as RoomDTO;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ROOM-001", result.Id);
            Assert.Equal("Deluxe", result.Type);
            Assert.Equal(2, result.Occupancy);
        }

        [Fact]
        public void Map_NullRoom_ThrowsInvalidMappingException()
        {
            // Arrange
            var mapper = new RoomToRoomDTOMapper();

            // Act & Assert
            Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
        }
    }

}

