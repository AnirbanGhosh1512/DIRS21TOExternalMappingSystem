using Xunit;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;

public class GoogleRoomToGoogleRoomDTOMapperTests
{
    [Fact]
    public void Map_ValidGoogleRoom_ReturnsGoogleRoomDTO()
    {
        // Arrange
        var mapper = new GoogleRoomToGoogleRoomDTOMapper();
        var googleRoom = new GoogleRoom
        {
            GoogleRoomId = "ROOM-101",
            RoomCategory = "Deluxe",
            MaxOccupancy = 3
        };

        // Act
        var result = mapper.Map(googleRoom) as GoogleRoomDTO;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("ROOM-101", result.GoogleRoomId);
        Assert.Equal("Deluxe", result.RoomCategory);
        Assert.Equal(3, result.MaxOccupancy);
    }

    [Fact]
    public void Map_NullGoogleRoom_ThrowsInvalidMappingException()
    {
        // Arrange
        var mapper = new GoogleRoomToGoogleRoomDTOMapper();

        // Act & Assert
        Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
    }

    [Fact]
    public void Map_InvalidSourceType_ThrowsInvalidMappingException()
    {
        // Arrange
        var mapper = new GoogleRoomToGoogleRoomDTOMapper();
        var invalidObject = new object(); // Passing an object that is not a GoogleRoom

        // Act & Assert
        var exception = Assert.Throws<InvalidMappingException>(() => mapper.Map(invalidObject));

        // Ensure the exception message indicates the type mismatch
        Assert.Equal("Expected GoogleRoom object but received something else.", exception.Message);
    }
}


