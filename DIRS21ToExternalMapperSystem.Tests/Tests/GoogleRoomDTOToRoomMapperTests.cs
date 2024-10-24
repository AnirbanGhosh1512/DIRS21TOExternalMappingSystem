using Xunit;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Mappers;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;

public class GoogleRoomDTOToRoomMapperTests
{
    [Fact]
    public void Map_ValidGoogleRoomDTO_ReturnsRoom()
    {
        // Arrange
        var mapper = new GoogleRoomDTOToRoomMapper();
        var googleRoomDTO = new GoogleRoomDTO
        {
            GoogleRoomId = "ROOM-001",
            RoomCategory = "Deluxe",
            MaxOccupancy = 2
        };

        // Act
        var result = mapper.Map(googleRoomDTO) as Room;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("ROOM-001", result.RoomId);
        Assert.Equal("Deluxe", result.RoomType);
        Assert.Equal(2, result.Capacity);
    }

    [Fact]
    public void Map_NullGoogleRoomDTO_ThrowsInvalidMappingException()
    {
        // Arrange
        var mapper = new GoogleRoomDTOToRoomMapper();

        // Act & Assert
        Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
    }

    [Fact]
    public void Map_InvalidSourceType_ThrowsInvalidMappingException()
    {
        // Arrange
        var mapper = new GoogleRoomDTOToRoomMapper();
        var invalidObject = new object();  // Passing an object that is not a GoogleRoomDTO

        // Act & Assert
        var exception = Assert.Throws<InvalidMappingException>(() => mapper.Map(invalidObject));

        // Ensure the exception message indicates the type mismatch
        Assert.Equal("Expected GoogleRoomDTO object but received something else.", exception.Message);
    }
}


