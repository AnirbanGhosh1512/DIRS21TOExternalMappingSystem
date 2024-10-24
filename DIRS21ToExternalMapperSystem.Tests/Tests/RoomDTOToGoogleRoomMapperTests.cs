using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Mappers;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;
using Xunit;

namespace DIRS21ToExternalMapperSystem.Tests
{

    public class RoomDTOToGoogleRoomMapperTests
    {
        [Fact]
        public void Map_ValidRoomDTO_ReturnsGoogleRoom()
        {
            // Arrange
            var mapper = new RoomDTOToGoogleRoomMapper();
            var roomDto = new RoomDTO
            {
                Id = "ROOM-001",
                Type = "Deluxe",
                Occupancy = 3
            };

            // Act
            var result = mapper.Map(roomDto) as GoogleRoom;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ROOM-001", result.GoogleRoomId);
            Assert.Equal("Deluxe", result.RoomCategory);
            Assert.Equal(3, result.MaxOccupancy);
        }

        [Fact]
        public void Map_NullRoomDTO_ThrowsInvalidMappingException()
        {
            // Arrange
            var mapper = new RoomDTOToGoogleRoomMapper();

            // Act & Assert
            Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
        }
    }

}

